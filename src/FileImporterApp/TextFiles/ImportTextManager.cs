using System;
using DokuFlex.Windows.Common.Services;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Generic;
using DokuFlex.Windows.Common.Services.Data;
using System.Text;
using System.Linq;
using DokuFlex.WinForms.Common;
using log4net;

namespace FileImporterApp.TextFiles
{
    public class ImportTextManager
    {
        private ImportTextViewModel viewModel;
        private ImportTextProgressForm progressForm;
        private const string FILE_NAME = ".\\importTextStore.json";
        private readonly ILog log;
        private readonly IDataService dataService;

        public ImportTextManager()
        {
            log = LogManager.GetLogger(GetType());
            dataService = DataServiceFactory.Create();
        }

        public bool Importing { get; private set; }

        private string[] GetFieldValues(string textLine)
        {
            return textLine.Split(viewModel.Model.FieldDelimiter);
        }

        public Dictionary<string, List<DokuField>> GetUploadList()
        {
            var list = new Dictionary<string, List<DokuField>>();
            var isFirstRow = true;
            var spColIndex = GetFileNameColumnIndex();

            using (var reader = new StreamReader(File.OpenRead(viewModel.Model.FilePath), Encoding.GetEncoding("iso-8859-1"), false))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();

                    if (isFirstRow)
                    {
                        isFirstRow = false;
                        continue;
                    }

                    var dokuFields = new List<DokuField>();
                    var fieldValues = GetFieldValues(line);

                    for (int i = 0; i < fieldValues.Length; i++)
                    {
                        var dokuField = CreateDokuFieldFromFieldIndex(i);

                        if (dokuField != null)
                        {
                            dokuField.value = fieldValues[i];
                            dokuFields.Add(dokuField);
                        }
                    }

                    list.Add(fieldValues[spColIndex], dokuFields);
                }
            }

            return list;
        }

        private int GetFileNameColumnIndex()
        {
            var metadata = viewModel.Model.MetadataCollection.FirstOrDefault(f => f.DokufieldName.Equals("_FILENAME"));
            return metadata != null ? metadata.FieldNameIndex : 0;
        }

        private DokuField CreateDokuFieldFromFieldIndex(int fieldIndex)
        {
            var medatada = viewModel.Model.MetadataCollection.FirstOrDefault(f => f.FieldNameIndex.Equals(fieldIndex));

            if (medatada == null || medatada.DokufieldType.Equals("E"))
                return null;

            var newDkField = new DokuField
            {
                id = medatada.DokufieldId,
                key = medatada.DokufieldName,
                type = medatada.DokufieldType,
            };

            return newDkField;
        }

        public void StopImport()
        {

        }

        private ImportTextViewModel LoadFromStore()
        {
            var str = File.Exists(FILE_NAME) ? File.ReadAllText(FILE_NAME) : string.Empty;

            if (string.IsNullOrWhiteSpace(str))
                return new ImportTextViewModel();

            JObject jObject = JObject.Parse(str);
            var jsonSerializer = new JsonSerializer();
            var configObject = (ImportTextViewModel)jsonSerializer.Deserialize(new JTokenReader(jObject), typeof(ImportTextViewModel));
            return configObject;
        }

        private void SaveToStore(ImportTextViewModel viewModel)
        {
            var jObject = JObject.FromObject(viewModel);
            File.WriteAllText(FILE_NAME, jObject.ToString());
        }

        private void ResumeImport()
        {

        }

        private async Task BeginImport()
        {
            var token = await Session.GetTikectAsync();

            if (string.IsNullOrWhiteSpace(token))
                return;

            var counter = 0;
            var filename = string.Empty;

            try
            {
                var uploadList = GetUploadList();

                CreateProgressWindow();

                foreach (var item in uploadList)
                {
                    if (counter < viewModel.LastUploadedIndex)
                        continue;

                    filename = item.Key;
                    UpdateProgress(counter + 1, uploadList.Count);

                    var result = await dataService.UploadAsync(token, viewModel.Model.CommunityId, string.Empty, viewModel.Model.DocumentaryId, string.Empty,
                        string.Empty, true, string.Empty, string.Empty, false, new FileInfo(item.Key));

                    if (result != null)
                    {
                        log.Info($"Successfully imported file: {item.Key}");
                        await dataService.UpdateDocumentMetadataAsync(token, viewModel.Model.DocumentaryId, result.nodeId, item.Value.ToArray());
                        log.Info($"Updated metadata for: {result.nodeId}");
                    }

                    counter++;
                }
            }
            catch (Exception ex)
            {
                log.Error($"Can't import file: {filename}", ex);
                MessageBox.Show("Ha ocurrido un error mientras se importaban los datos", "File Importer", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                CloseProgressWindow();
            }
        }

        private void CloseProgressWindow()
        {
            if (progressForm != null)
            {
                progressForm.Close();
                progressForm.Dispose();
                progressForm = null;
            }
        }

        private void CreateProgressWindow()
        {
            if (progressForm == null)
                progressForm = new ImportTextProgressForm();
        }

        private void UpdateProgress(int index, int count)
        {
            progressForm.Show();
            progressForm.UpdateProgress(index, count);
        }

        public async Task StartImport()
        {
            viewModel = LoadFromStore();

            if (viewModel.Halted)
            {
                if (MessageBox.Show(Resources.ResumeImportText, "FileImporter", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ResumeImport();
                }
                else
                    await BeginImport();
            }
            else
            {
                viewModel = new ImportTextViewModel();

                using (var importForm = new ImportTextForm(viewModel))
                {
                    if (importForm.ShowDialog() == DialogResult.OK)
                    {
                        await BeginImport();
                    }
                }
            }
        }
    }
}
