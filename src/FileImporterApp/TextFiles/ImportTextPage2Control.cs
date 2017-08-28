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
    public partial class ImportTextPage2Control : UserControl
    {
        public ImportTextPage2Control()
        {
            InitializeComponent();
        }

        public ImportTextModel Model
        {
            get { return bindingSource.Current as ImportTextModel; }
            set
            {
                bindingSource.DataSource = value;
                bindingSource.ResetBindings(true);
                bsMetadata.DataSource = value?.MetadataCollection;
                bsMetadata.ResetBindings(true);
            }
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
            var fieldNames = GetFieldNames(Model.FilePath, Model.FieldDelimiter);
            var collection = new FieldNameIndexCollection();

            for (int i = 0; i < fieldNames.Length; i++)
            {
                collection.Add(new FieldNameIndex { Index = i, Name = fieldNames[i]});
            }

            return collection;
        }

        private void rbtnSemicolon_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as RadioButton).Checked)
            {
                Model.FieldDelimiter = ';';
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
            foreach (var metadata in Model.MetadataCollection)
            {
                metadata.FieldName = string.Empty;
                metadata.FieldNameIndex = 0;
            }
        }

        private void rbtnComa_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as RadioButton).Checked)
            {
                Model.FieldDelimiter = ',';
                var collection = GetFieldNameIndexCollection();
                ClearMetadataFieldValues();
                CreateColFieldNameDataSource(collection);
            }
        }

        private void rbtnSpace_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as RadioButton).Checked)
            {
                Model.FieldDelimiter = ' ';
                var collection = GetFieldNameIndexCollection();
                ClearMetadataFieldValues();
                CreateColFieldNameDataSource(collection);
            }
        }

        private void rbtnScriptUnder_CheckedChanged(object sender, EventArgs e)
        {

            if ((sender as RadioButton).Checked)
            {
                Model.FieldDelimiter = '_';
                var collection = GetFieldNameIndexCollection();
                ClearMetadataFieldValues();
                CreateColFieldNameDataSource(collection);
            }
        }
    }
}
