using FileImporterApp.Metadata;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileImporterApp.FolderConfig
{
    public class ImportFolderConfigViewModel
    {
        private ImportFolderConfig model;

        public ImportFolderConfig Model
        {
            get => model;
            set
            {
                model = value;
                MetadataList = model != null ? new BindingList<MetadataItem>(model.MetadataCollection) : new BindingList<MetadataItem>();
            }
        }

        public BindingList<MetadataItem> MetadataList { get; private set; }
    }
}
