using DokuFlex.Windows.Common.Services;
using DokuFlex.Windows.Common.Services.Data;
using DokuFlex.WinForms.Common;
using FileImporterApp.Metadata;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileImporterApp.TextFiles
{
    public class ImportTextViewModel
    {
        private ImportTextModel model;
        private readonly IDataService dataService;

        public ImportTextViewModel(IDataService dataService)
        {
            this.dataService = dataService;
        }

        public ImportTextModel Model
        {
            get => model;
            set
            {
                model = value;
                MetadataList = model != null ? new BindingList<MetadataItem>(model.MetadataCollection) : new BindingList<MetadataItem>();
            }
        }

        public BindingList<Documentary> DocumentaryList { get; private set; }
        public BindingList<MetadataItem> MetadataList { get; private set; }

        public async Task LoadListData(string token)
        {
            if (string.IsNullOrWhiteSpace(token))
                throw new ArgumentNullException(nameof(token));

            var documentaries = await dataService.GetDocumentaryTypesAsync(token);
            DocumentaryList = new BindingList<Documentary>(documentaries);
        }

        public bool FilePathExists()
            => !string.IsNullOrWhiteSpace(model?.FilePath) && File.Exists(model.FilePath);

        public void AddFileNameMetadata()
        {
            if (MetadataList.Any(e => e.DokufieldName.Equals("_FILENAME")))
                return;

            MetadataList.Add(new MetadataItem
            {
                DokufieldId = Guid.NewGuid().ToString(),
                DokufieldType = "_FN",
                DokufieldName = "_FILENAME",
                Mandatory = true
            });
        }

        public Dictionary<string, List<DokuField>> GetUploadList()
        {
            if (model == null)
                throw new ArgumentNullException(nameof(Model));

            var list = new Dictionary<string, List<DokuField>>();
            var isFirstRow = true;
            var spColIndex = GetFileNameColumnIndex();

            using (var reader = new StreamReader(File.OpenRead(Model.FilePath), Encoding.GetEncoding("iso-8859-1"), false))
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
            var metadata = Model?.MetadataCollection.FirstOrDefault(f => f.DokufieldType == "_FN");
            return metadata != null ? metadata.FieldNameIndex : 0;
        }

        private DokuField CreateDokuFieldFromFieldIndex(int fieldIndex)
        {
            var medatada = Model?.MetadataCollection.FirstOrDefault(f => f.FieldNameIndex.Equals(fieldIndex));

            if (medatada == null || medatada.DokufieldType == "_FN")
                return null;

            var newDkField = new DokuField
            {
                id = medatada.DokufieldId,
                key = medatada.DokufieldName,
                type = medatada.DokufieldType,
            };

            return newDkField;
        }

        private string[] GetFieldValues(string textLine)
        {
            return textLine.Split(Model.FieldDelimiter);
        }
    }
}
