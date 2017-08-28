using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileImporterApp.TextFiles
{
    public partial class ImportTextProgressForm : Form
    {
        public ImportTextProgressForm()
        {
            InitializeComponent();
        }

        public void UpdateProgress(int index, int count)
        {
            progressText.Text = $"Importando archivos {index} de {count}";
            progressBar.Maximum = count;
            progressBar.PerformStep();
        }
    }
}
