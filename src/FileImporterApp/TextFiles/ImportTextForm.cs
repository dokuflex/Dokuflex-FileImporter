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
    public partial class ImportTextForm : Form
    {
        private List<Control> pageList;

        public ImportTextForm()
        {
            InitializeComponent();
        }

        public ImportTextForm(ImportTextViewModel viewModel)
            : this()
        {
            ViewModel = viewModel;
            CreateWizardPages();
            GoToPage(PageIndex);
            UpdateNavButtonsStatus();
        }

        private void CreateWizardPages()
        {
            pageList = new List<Control>
            {
                new ImportTextPage1Control(ViewModel)
                {
                    Parent = wizardPane,
                    Dock = DockStyle.Fill
                },

                new ImportTextPage2Control(ViewModel)
                {
                    Parent = wizardPane,
                    Dock = DockStyle.Fill
                },

                new ImportTextPage3Control(ViewModel)
                {
                    Parent = wizardPane,
                    Dock = DockStyle.Fill
                }
            };
        }

        public ImportTextViewModel ViewModel { get; private set; }
        public int PageIndex { get; private set; } = 0;
        public int PageCount { get { return pageList.Count; } }

        private void GoToPage(int index)
        {
            pageList[index].BringToFront();
        }

        private bool CanNavigateFrom(int pageIndex)
        {
            var pageValidation = pageList[pageIndex] as IControlDataValidation;
            return pageValidation == null ? false : !pageValidation.HasErrors();
        }

        private void BtnNext_Click(object sender, EventArgs e)
        {
            if (!CanNavigateFrom(PageIndex))
                return;

            PageIndex++;
            GoToPage(PageIndex);
            UpdateNavButtonsStatus();
        }

        private void BtnPrior_Click(object sender, EventArgs e)
        {
            PageIndex--;
            GoToPage(PageIndex);
            UpdateNavButtonsStatus();
        }

        private void UpdateNavButtonsStatus()
        {
            btnPrior.Enabled = PageIndex > 0;
            btnNext.Enabled = PageIndex < PageCount - 1;
            btnFinalize.Enabled = PageIndex == PageCount - 1;
        }

        private void BtnFinalize_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
