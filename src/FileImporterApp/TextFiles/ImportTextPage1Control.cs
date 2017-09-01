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
    public partial class ImportTextPage1Control : UserControl, IControlDataValidation
    {
        private readonly ImportTextViewModel viewModel;

        public ImportTextPage1Control()
        {
            InitializeComponent();
        }

        public ImportTextPage1Control(ImportTextViewModel viewModel)
            : this()
        {
            this.viewModel = viewModel;
            BindComponents();
        }

        private void BindComponents()
        {
            cbxDocumentryTypes.DataSource = viewModel.DocumentaryList;
            bindingSource.DataSource = viewModel.Model;
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
                    viewModel.Model.FilePath = openFileDlg.FileName;
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
                    viewModel.Model.CommunityId = form.Group.id;
                    viewModel.Model.FolderId = form.Folder.id;
                    viewModel.Model.FolderPath = form.FullPath;
                    bindingSource.ResetCurrentItem();
                }
            }
        }

        private void cbxDocumentryTypes_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cbxDocumentryTypes.SelectedItem is Documentary documentary)
            {
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

                viewModel.AddFileNameMetadata();
            }
        }

        public bool HasErrors()
        {
            var result = false;

            if (IsFilePathValid())
                errorProvider.SetError(tbxSourceFile, string.Empty);
            else
            {
                result = true;
                errorProvider.SetError(tbxSourceFile, "La ruta del archivo es requerida");
            }

            if (IsDocumentaryValid())
                errorProvider.SetError(cbxDocumentryTypes, string.Empty);
            else
            {
                result = true;
                errorProvider.SetError(cbxDocumentryTypes, "El tipo documental no es valido");
            }

            if (IsFolderValid())
                errorProvider.SetError(tbxFolderPath, string.Empty);
            else
            {
                result = true;
                errorProvider.SetError(tbxFolderPath, "La carpeta de destino no es valida");
            }

            return result;
        }

        private bool IsFilePathValid()
            => viewModel.FilePathExists();

        private bool IsDocumentaryValid()
            => !string.IsNullOrWhiteSpace(viewModel.Model.DocumentaryId);

        public bool IsFolderValid()
            => !string.IsNullOrWhiteSpace(viewModel.Model.FolderId);
    }
}
