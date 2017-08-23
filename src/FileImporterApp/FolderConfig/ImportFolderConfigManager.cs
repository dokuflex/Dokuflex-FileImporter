using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;

namespace FileImporterApp.FolderConfig
{
    public class ImportFolderConfigManager
    {
        private const string FILE_NAME = ".\\FolderConfig.json";

        public ImportFolderConfig OpenConfiguration()
        {
            var str = File.Exists(FILE_NAME) ? File.ReadAllText(FILE_NAME) : string.Empty;

            if (string.IsNullOrWhiteSpace(str))
                return new ImportFolderConfig();

            JObject jObject = JObject.Parse(str);
            var jsonSerializer = new JsonSerializer();
            var configObject = (ImportFolderConfig)jsonSerializer.Deserialize(new JTokenReader(jObject), typeof(ImportFolderConfig));
            return configObject;
        }

        public void SaveConfiguration(ImportFolderConfig config)
        {
            var jObject = JObject.FromObject(config);
            File.WriteAllText(FILE_NAME, jObject.ToString());
        }
    }
}
