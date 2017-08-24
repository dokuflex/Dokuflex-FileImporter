namespace FileImporterApp.Metadata
{
    public class MetadataItem
    {
        public string DokufieldId { get; set; }
        public string DokufieldName { get; set; }
        public string DokufieldType { get; set; }
        public bool Mandatory { get; set; }
        public string FieldName { get; set; }
        public int FieldNameIndex { get; set; }
    }
}
