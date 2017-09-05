using DokuFlex.Windows.Common.Services;
using DokuFlex.WinForms.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileImporterApp.FolderConfig
{
    public class ImportFolderManager
    {
        private ImportFolderViewModel viewModel;
        private readonly IDataService dataService;
        private const string FILE_NAME = ".\\FolderConfig.json";

        public ImportFolderManager()
        {
            dataService = DataServiceFactory.Create();
            viewModel = new ImportFolderViewModel(dataService)
            {
                Model = LoadModelFromStore()
            };
        }

        public ImportFolderModel FolderConfig { get => viewModel?.Model; }

        private ImportFolderModel LoadModelFromStore()
        {
            var str = File.Exists(FILE_NAME) ? File.ReadAllText(FILE_NAME) : string.Empty;

            if (string.IsNullOrWhiteSpace(str))
                return new ImportFolderModel();

            JObject jObject = JObject.Parse(str);
            var jsonSerializer = new JsonSerializer();
            var configObject = (ImportFolderModel)jsonSerializer.Deserialize(new JTokenReader(jObject), typeof(ImportFolderModel));
            return configObject;
        }

        private void SaveModelToStore(ImportFolderModel config)
        {
            var jObject = JObject.FromObject(config);
            File.WriteAllText(FILE_NAME, jObject.ToString());
        }

        public async Task<bool> ShowConfigForm()
        {
            var token = await Session.GetTikectAsync();

            if (string.IsNullOrWhiteSpace(token))
            {
                MessageBox.Show("No se pudo establecer conexión con el servicio, asegurese que los parámetros de conexión y sus credenciales sean correctas", "FileImporter", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            viewModel.ClearListData();
            await viewModel.LoadListData(token);

            using (var form = new ImportFolderForm(viewModel))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    SaveModelToStore(viewModel.Model);
                    return true;
                }
                else
                {
                    viewModel.Model = LoadModelFromStore();
                }
            }

            return false;
        }
    }
}
