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
using log4net;
using DokuFlex.WinForms.Common;

namespace FileImporterApp.TextFiles
{
    public class ImportTextManager
    {
        private string token;
        private ImportTextViewModel viewModel;
        private ImportTextProgressForm progressForm;
        private const string FILE_NAME = ".\\importTextStore.json";
        private readonly ILog log;
        private readonly IDataService dataService;

        public ImportTextManager()
        {
            log = LogManager.GetLogger(GetType());
            dataService = DataServiceFactory.Create();
            viewModel = new ImportTextViewModel(dataService)
            {
                Model = new ImportTextModel()
            };
        }

        public bool Importing { get; private set; }

        private ImportTextModel LoadModelFromStore()
        {
            var str = File.Exists(FILE_NAME) ? File.ReadAllText(FILE_NAME) : string.Empty;

            if (string.IsNullOrWhiteSpace(str))
                return new ImportTextModel();

            JObject jObject = JObject.Parse(str);
            var jsonSerializer = new JsonSerializer();
            var configObject = (ImportTextModel)jsonSerializer.Deserialize(new JTokenReader(jObject), typeof(ImportTextModel));
            return configObject;
        }

        private void SaveModelToStore(ImportTextModel model)
        {
            var jObject = JObject.FromObject(model);

            try
            {
                File.WriteAllText(FILE_NAME, jObject.ToString());
            }
            catch (Exception ex)
            {
                log.Error("Can't save model to the import text store", ex);
            }
        }

        private void ClearModelFromStore()
        {
            SaveModelToStore(new ImportTextModel());
        }

        private async Task BeginImport()
        {
            var counter = 0;
            var filename = string.Empty;

            try
            {
                var uploadList = viewModel.GetUploadList();

                CreateProgressWindow();

                viewModel.Model.Halted = true;

                foreach (var item in uploadList)
                {
                    if (!Importing)
                        break;

                    if (counter < viewModel.Model.UploadIndex)
                    {
                        counter++;
                        continue;
                    }

                    SaveModelToStore(viewModel.Model);

                    filename = item.Key;
                    UpdateProgress(counter + 1, uploadList.Count);

                    var result = await dataService.UploadAsync(token, viewModel.Model.CommunityId, string.Empty, viewModel.Model.FolderId, string.Empty,
                        string.Empty, true, string.Empty, string.Empty, false, new FileInfo(item.Key));

                    if (result != null)
                    {
                        log.Info($"Successfully imported file: {item.Key}");
                        await dataService.UpdateDocumentMetadataAsync(token, viewModel.Model.DocumentaryId, result.nodeId, item.Value.ToArray());
                        log.Info($"Updated metadata for: {result.nodeId}");
                    }

                    counter++;
                    viewModel.Model.UploadIndex++;
                }

                viewModel.Model.Halted = false;
                SaveModelToStore(new ImportTextModel());
            }
            catch (Exception ex)
            {
                log.Error($"Can't import file: {filename}", ex);
                MessageBox.Show("Ha ocurrido un error mientras se importaban los datos", "File Importer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                StopImport();
            }
        }

        private void CloseProgressWindow()
        {
            if (progressForm != null)
            {
                progressForm.Close();
                progressForm.FormClosing -= ProgressForm_FormClosing;
                progressForm.Dispose();
                progressForm = null;
            }
        }

        private void CreateProgressWindow()
        {
            if (progressForm == null)
            {
                progressForm = new ImportTextProgressForm();
                progressForm.FormClosing += ProgressForm_FormClosing;
            }

        }

        private void ProgressForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Importing)
            {
                if (MessageBox.Show("¿Desea cancelar la importación de archivos?", "FileImporter", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    Importing = false;
                }
                else
                    e.Cancel = true;
            }
        }

        private void UpdateProgress(int index, int count)
        {
            progressForm.Show();
            progressForm.UpdateProgress(index, count);
        }

        private async Task<bool> CreateToken()
        {
            token = await Session.GetTikectAsync();
            return !string.IsNullOrWhiteSpace(token);
        }

        public async Task StartImport()
        {
            Importing = true;
            log.Info("Import text started!");

            try
            {
                var model = LoadModelFromStore();

                if (model.Halted)
                {
                    model.Halted = false;

                    ClearModelFromStore();

                    if (MessageBox.Show(Resources.ResumeImportText, "FileImporter", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        viewModel.Model = model;

                        if (await CreateToken())
                            await BeginImport();

                    }
                    else
                    {
                        await RunImportWizard();
                    }
                }
                else
                    await RunImportWizard();
            }
            finally
            {
                Importing = false;
                CloseProgressWindow();
                log.Info("Import text finalized!");
            }
        }

        public void StopImport()
        {
            if (Importing)
            {
                Importing = false;
                CloseProgressWindow();

                if (viewModel.Model != null)
                    SaveModelToStore(viewModel.Model);
            }
        }

        private async Task RunImportWizard()
        {
            viewModel.ClearListData();

            if (await CreateToken())
            {
                await viewModel.LoadListData(token);

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
