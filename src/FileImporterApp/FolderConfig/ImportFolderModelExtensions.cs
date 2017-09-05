using DokuFlex.Windows.Common.Services.Data;
using System.Collections.Generic;
using System.Linq;

namespace FileImporterApp.FolderConfig
{
    public static class ImportFolderModelExtensions
    {
        public static List<DokuField> GetDokuFieldList(this ImportFolderModel folderConfig, string fileName)
        {
            var list = new List<DokuField>();
            var fieldValues = fileName.Split(folderConfig.FieldDelimiter);

            for (int i = 0; i < fieldValues.Length; i++)
            {
                var dokuField = CreateDokuFieldFromFieldIndex(i);

                if (dokuField != null)
                {
                    dokuField.value = fieldValues[i];
                    list.Add(dokuField);
                }
            }

            DokuField CreateDokuFieldFromFieldIndex(int fieldIndex)
            {
                var metadata = folderConfig.MetadataCollection.FirstOrDefault(f => f.FieldNameIndex.Equals(fieldIndex));

                if (metadata == null)
                    return null;

                var newDkField = new DokuField
                {
                    id = metadata.DokufieldId,
                    key = metadata.DokufieldName,
                    type = metadata.DokufieldType,
                };

                return newDkField;
            }

            return list;
        }
    }
}
