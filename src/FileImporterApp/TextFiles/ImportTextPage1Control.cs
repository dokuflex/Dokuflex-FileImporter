using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DokuFlex.Windows.Common.Services.Data;
using DokuFlex.WinForms.Common;

namespace FileImporterApp.TextFiles
{
    public partial class ImportTextPage1Control : UserControl
    {
        public ImportTextPage1Control()
        {
            InitializeComponent();
            Model = new ImportTextModel();
        }

        public void SetDocumentaryList(List<Documentary> documentaries)
        {
            cbxDocumentryTypes.DataSource = new BindingList<Documentary>(documentaries);
        }

        public string Token { get; set; }

        public ImportTextModel Model
        {
            get { return bindingSource.Current as ImportTextModel; }
            set
            {
                bindingSource.DataSource = value;
                bindingSource.ResetBindings(true);
            }
        }

        private void BtnBrowsePC_Click(object sender, EventArgs e)
        {
            using (var openFileDlg = new OpenFileDialog {
                Title = Resources.SelectFileText,
                Filter = "TODOS|*.*"
            })
            {
                if (openFileDlg.ShowDialog() == DialogResult.OK)
                {
                    tbxSourceFile.Text = openFileDlg.FileName;
                }
            }
        }

        private void BtnBrowseCloud_Click(object sender, EventArgs e)
        {
            using (var form = new BrowseFolderForm(Token))
            {
                if (form.ShowFolderBrowserDialog())
                {
                    Model.CommunityId = form.Group.id;
                    Model.FolderId = form.Folder.id;
                    Model.FolderPath = form.FullPath;
                    bindingSource.ResetCurrentItem();
                }
            }
        }
    }
}
