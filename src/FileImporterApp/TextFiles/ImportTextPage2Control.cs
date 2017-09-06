using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace FileImporterApp.TextFiles
{
    public partial class ImportTextPage2Control : UserControl, IControlDataValidation
    {
        private readonly ImportTextViewModel viewModel;

        public ImportTextPage2Control()
        {
            InitializeComponent();
        }

        public ImportTextPage2Control(ImportTextViewModel viewModel)
            : this()
        {
            this.viewModel = viewModel;
            BindComponents();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            var emptycollection = CreateEmptyCollection();
            CreateColFieldNameDataSource(emptycollection);
        }

        private void BindComponents()
        {
            bindingSource.DataSource = viewModel.Model;
            bsMetadata.DataSource = viewModel.MetadataList;
        }

        private string[] GetFieldNames(string fileName, char delimiter)
        {
            using (var reader = new StreamReader(File.OpenRead(fileName), Encoding.GetEncoding("iso-8859-1"), false))
            {
                if (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    return line.Split(delimiter);
                }
            }

            return new string[] { };
        }

        private FieldNameIndexCollection GetFieldNameIndexCollection()
        {
            var collection = new FieldNameIndexCollection();
            collection.Add(new FieldNameIndex { Index = -1, Name = "(Vacio)" });

            if (!viewModel.FilePathExists())
                return collection;

            var fieldNames = GetFieldNames(viewModel.Model.FilePath, viewModel.Model.FieldDelimiter);

            for (int i = 0; i < fieldNames.Length; i++)
            {
                collection.Add(new FieldNameIndex { Index = i, Name = fieldNames[i]});
            }

            return collection;
        }

        private FieldNameIndexCollection CreateEmptyCollection()
        {
            return new FieldNameIndexCollection
            {
                new FieldNameIndex{ Name = "(Vacio)", Index = -1 }
            };
        }

        private void rbtnSemicolon_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as RadioButton).Checked)
            {
                viewModel.Model.FieldDelimiter = ';';
                var collection = GetFieldNameIndexCollection();
                ClearMetadataFieldValues();
                CreateColFieldNameDataSource(collection);
            }
        }

        private void CreateColFieldNameDataSource(FieldNameIndexCollection collection)
        {
            var datasource = new BindingList<FieldNameIndex>(collection);
            colFieldName.DataSource = datasource;
            colFieldName.DisplayMember = "Name";
            colFieldName.ValueMember = "Index";
        }

        public void ResetBinding()
        {
            bindingSource.ResetCurrentItem();
        }

        private void ClearMetadataFieldValues()
        {
            foreach (var metadata in viewModel.MetadataList)
            {
                metadata.FieldName = string.Empty;
                metadata.FieldNameIndex = -1;
            }
        }

        private void rbtnComa_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as RadioButton).Checked)
            {
                viewModel.Model.FieldDelimiter = ',';
                var collection = GetFieldNameIndexCollection();
                ClearMetadataFieldValues();
                CreateColFieldNameDataSource(collection);
            }
        }

        private void rbtnSpace_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as RadioButton).Checked)
            {
                viewModel.Model.FieldDelimiter = ' ';
                var collection = GetFieldNameIndexCollection();
                ClearMetadataFieldValues();
                CreateColFieldNameDataSource(collection);
            }
        }

        private void rbtnScriptUnder_CheckedChanged(object sender, EventArgs e)
        {

            if ((sender as RadioButton).Checked)
            {
                viewModel.Model.FieldDelimiter = '_';
                var collection = GetFieldNameIndexCollection();
                ClearMetadataFieldValues();
                CreateColFieldNameDataSource(collection);
            }
        }

        public bool HasErrors()
        {
            var result = false;

            if (IsMetadaValid())
                errorProvider.SetError(dataGridView1, string.Empty);
            else
            {
                result = true;
                errorProvider.SetError(dataGridView1, "Hay campos requeridos que no están correctamente mapeados");
            }

            return result;
        }

        private bool IsMetadaValid()
        {
            foreach (var metadata in viewModel.MetadataList)
            {
                if (metadata.Mandatory && metadata.FieldNameIndex == -1)
                    return false;

            }

            return true;
        }
    }
}
