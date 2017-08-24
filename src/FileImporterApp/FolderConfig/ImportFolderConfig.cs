using FileImporterApp.Metadata;

namespace FileImporterApp.FolderConfig
{
    public class ImportFolderConfig
    {
        public string DirectoryPath { get; set; }
        public string FileExtensions { get; set; }
        public char FieldDelimiter { get; set; }
        public string CommunityId { get; set; }
        public string FolderId { get; set; }
        public bool UseFolderPattern { get; set; }
        public string FolderPattern { get; set; }
        public string DocumentaryId { get; set; }
        public MetadataItemCollection MetadataCollection { get; private set; } = new MetadataItemCollection();
        public bool DeleteImportedFiles { get; set; }
    }
}
