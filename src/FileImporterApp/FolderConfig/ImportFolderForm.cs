using DokuFlex.Windows.Common.Services.Data;
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

namespace FileImporterApp.FolderConfig
{
    public partial class ImportFolderForm : Form
    {
        private bool loading;
        private readonly ImportFolderViewModel viewModel;

        public ImportFolderForm()
        {
            InitializeComponent();
        }

        public ImportFolderForm(ImportFolderViewModel viewModel)
            : this()
        {
            this.viewModel = viewModel;

            BindComponents();
        }

        private void BindComponents()
        {
            loading = true;
            try
            {
                bindingSource.DataSource = viewModel.Model;
                cbxDocumentaryTypes.DataSource = viewModel.DocumentaryList;
                cbxDelimiters.DataSource = viewModel.FieldDelimiterList;
                bsMetadata.DataSource = viewModel.MetadataList;
            }
            finally
            {
                loading = false;
            }
        }

        private void cbxDocumentaryTypes_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cbxDocumentaryTypes.SelectedItem is Documentary documentary)
            {
                if (loading) return;
                if (documentary.id == viewModel.Model.DocumentaryId) return;

                viewModel.MetadataList.Clear();

                foreach (var dokufield in documentary.elements)
                {
                    viewModel.MetadataList.Add(new MetadataItem
                    {
                        DokufieldId = dokufield.id,
                        DokufieldType = dokufield.type,
                        DokufieldName = dokufield.key,
                        Mandatory = dokufield.mandatory > 0
                    });
                }
            }
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            using (var browseDlg = new FolderBrowserDialog())
            {
                if (browseDlg.ShowDialog() == DialogResult.OK)
                {
                    viewModel.Model.DirectoryPath = browseDlg.SelectedPath;
                    bindingSource.ResetCurrentItem();
                }
            }
        }

        private async void btnBrowse_Click(object sender, EventArgs e)
        {
            var token = await Session.GetTikectAsync();

            if (string.IsNullOrWhiteSpace(token))
                return;

            using (var form = new BrowseFolderForm(token))
            {
                if (form.ShowFolderBrowserDialog())
                {
                    viewModel.Model.CommunityId = form.Group.id;
                    viewModel.Model.FolderId = form.Folder.id;
                    viewModel.Model.FolderPath = form.FullPath;
                    bindingSource.ResetCurrentItem();
                }
            }
        }
    }
}
