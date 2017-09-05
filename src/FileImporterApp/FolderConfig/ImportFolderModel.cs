using System.Linq;
using FileImporterApp.Metadata;

namespace FileImporterApp.FolderConfig
{
    public class ImportFolderModel
    {
        public string DirectoryPath { get; set; }
        public string FileExtensions { get; set; }
        public char FieldDelimiter { get; set; } = '_';
        public string CommunityId { get; set; }
        public string FolderId { get; set; }
        public string FolderPath { get; set; }
        public bool UseFolderPattern { get; set; }
        public string FolderPattern { get; set; }
        public string DocumentaryId { get; set; }
        public MetadataItemCollection MetadataCollection { get; private set; } = new MetadataItemCollection();
        public bool DeleteImportedFiles { get; set; }

        public bool IsExtensionValid(string extension)
        {
            if (string.IsNullOrEmpty(FileExtensions))
                return true;

            var extensions = FileExtensions.ToLowerInvariant().Split(',');
            return extensions.Contains(extension.ToLowerInvariant());
        }
    }
}