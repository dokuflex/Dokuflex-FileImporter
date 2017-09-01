using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileImporterApp.TextFiles
{
    public partial class ImportTextPage3Control : UserControl
    {
        private readonly ImportTextViewModel viewModel;

        public ImportTextPage3Control()
        {
            InitializeComponent();
        }

        public ImportTextPage3Control(ImportTextViewModel viewModel)
            : this()
        {
            this.viewModel = viewModel;
        }
    }
}
