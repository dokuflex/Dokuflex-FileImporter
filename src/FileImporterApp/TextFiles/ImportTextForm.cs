using DokuFlex.Windows.Common.Services;
using DokuFlex.WinForms.Common;
using FileImporterApp.Metadata;
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
        private readonly List<Control> pageList;
        private readonly IDataService dataService;

        public ImportTextForm()
        {
            InitializeComponent();

            pageList = new List<Control>
            {
                importTextPage1Control1,
                importTextPage2Control1,
                importTextPage3Control1
            };

            GoToPage(PageIndex);
            UpdateNavButtonsStatus();

            dataService = DataServiceFactory.Create();
        }

        public ImportTextForm(ImportTextViewModel viewModel)
            : this()
        {
            ViewModel = viewModel;
            ViewModel.Model.AddFileNameMetadata();
            BindComponents();
        }

        private void BindComponents()
        {
            importTextPage1Control1.Model = ViewModel.Model;
            importTextPage2Control1.Model = ViewModel.Model;
        }

        protected override async void OnLoad(EventArgs e)
        {
            var token = await Session.GetTikectAsync();

            if (string.IsNullOrWhiteSpace(token))
                return;

            try
            {
                var documentaries = await dataService.GetDocumentaryTypesAsync(token);
                importTextPage1Control1.SetDocumentaryList(documentaries);
            }
            catch (Exception ex)
            {


            }
        }

        public ImportTextViewModel ViewModel { get; private set; }
        public int PageIndex { get; private set; } = 0;
        public int PageCount { get { return pageList.Count; } }

        private void GoToPage(int index)
        {
            pageList[index].BringToFront();
        }

        private void BtnNext_Click(object sender, EventArgs e)
        {
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

        private void btnFinalize_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
