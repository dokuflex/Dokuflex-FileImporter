using FileImporterApp.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileImporterApp.TextFiles
{
    public class ImportTextModel
    {
        public string FilePath { get; set; }
        public char FieldDelimiter { get; set; }
        public string CommunityId { get; set; }
        public string FolderPath { get; set; }
        public string FolderId { get; set; }
        public string DocumentaryId { get; set; }
        public MetadataItemCollection MetadataCollection { get; private set; } = new MetadataItemCollection();

        public void AddFileNameMetadata()
        {
            if (MetadataCollection.Any(e => e.DokufieldName.Equals("_FILENAME")))
                return;

            MetadataCollection.Add(new MetadataItem
            {
                DokufieldId = Guid.NewGuid().ToString(),
                DokufieldType = "E",
                DokufieldName = "_FILENAME",
                Mandatory = true
            });
        }
    }
}
