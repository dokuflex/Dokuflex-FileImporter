using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileImporterApp.TextFiles
{
    public class ImportTextViewModel
    {
        public ImportTextModel Model { get; private set; } = new ImportTextModel();
        public int LastUploadedIndex { get; set; }
        public bool Halted { get; set; }
    }
}
