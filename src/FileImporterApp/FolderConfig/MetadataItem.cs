using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileImporterApp.FolderConfig
{
    public class MetadataItem
    {
        public string DokufieldId { get; set; }
        public string DokufieldName { get; set; }
        public string DokufieldType { get; set; }
        public bool Mandatory { get; set; }
        public int FieldNameIndex { get; set; }
    }
}
