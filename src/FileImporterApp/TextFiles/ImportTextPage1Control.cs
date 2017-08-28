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
using FileImporterApp.Metadata;

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
                    Model.FilePath = openFileDlg.FileName;
                    bindingSource.ResetCurrentItem();
                }
            }
        }

        private async void BtnBrowseCloud_Click(object sender, EventArgs e)
        {
            var token = await Session.GetTikectAsync();

            if (string.IsNullOrWhiteSpace(token))
                return;

            using (var form = new BrowseFolderForm(token))
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

        private void bindingSource_CurrentItemChanged(object sender, EventArgs e)
        {

        }

        private void cbxDocumentryTypes_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbxDocumentryTypes_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cbxDocumentryTypes.SelectedItem is Documentary documentary)
            {
                Model.MetadataCollection.Clear();

                foreach (var dokufield in documentary.elements)
                {
                    Model.MetadataCollection.Add(new MetadataItem
                    {
                        DokufieldId = dokufield.id,
                        DokufieldType = dokufield.type,
                        DokufieldName = dokufield.key,
                        Mandatory = dokufield.mandatory > 0
                    });
                }

                Model.AddFileNameMetadata();
            }
        }

        private void btnLoadMetadata_Click(object sender, EventArgs e)
        {

        }
    }
}
