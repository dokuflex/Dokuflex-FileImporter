using DokuFlex.Windows.Common.Services;
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
        private ImportTextModel model;
        private readonly string token;
        private readonly List<Control> pageList;
        private readonly IDataService dataService;

        public ImportTextForm()
        {
            InitializeComponent();

            model = new ImportTextModel();

            pageList = new List<Control>
            {
                importTextPage1Control1,
                importTextPage2Control1,
                importTextPage3Control1
            };
        }

        public ImportTextForm(string token)
            : this()
        {
            this.token = token;
            dataService = DataServiceFactory.Create();
            importTextPage1Control1.Model = model;
            importTextPage1Control1.Token = token;
        }

        protected override async void OnLoad(EventArgs e)
        {
            GoToPage(PageIndex);
            UpdateNavButtonsStatus();

            try
            {
                var documentaries = await dataService.GetDocumentaryTypesAsync(token);
                importTextPage1Control1.SetDocumentaryList(documentaries);
            }
            catch (Exception ex)
            {


            }
        }

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
    }
}
