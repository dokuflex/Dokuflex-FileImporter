using DokuFlex.Windows.Common.Services;
using DokuFlex.Windows.Common.Services.Data;
using FileImporterApp.Metadata;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;

namespace FileImporterApp.FolderConfig
{
    public class ImportFolderViewModel
    {
        private readonly IDataService dataService;

        public ImportFolderViewModel(IDataService dataService)
        {
            this.dataService = dataService;

            var delimiters = new List<Tuple<string, char>>
            {
                new Tuple<string, char>("Punto y coma", ';'),
                new Tuple<string, char>("Coma", ','),
                new Tuple<string, char>("Espacio", ' '),
                new Tuple<string, char>("Guíon bajo", '_'),
            };

            FieldDelimiterList = new BindingList<Tuple<string, char>>(delimiters);
        }

        private ImportFolderModel model;

        public ImportFolderModel Model
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
        public BindingList<Tuple<string, char>> FieldDelimiterList { get; private set; }

        public async Task LoadListData(string token)
        {
            if (string.IsNullOrWhiteSpace(token))
                throw new ArgumentNullException(nameof(token));

            var documentaries = await dataService.GetDocumentaryTypesAsync(token);
            DocumentaryList = new BindingList<Documentary>(documentaries);
        }

        public void ClearListData()
        {
            DocumentaryList = null;
        }
    }
}
