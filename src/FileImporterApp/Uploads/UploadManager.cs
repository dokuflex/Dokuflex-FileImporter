using DokuFlex.Windows.Common.Services;
using DokuFlex.Windows.Common.Services.Data;
using DokuFlex.WinForms.Common;
using log4net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileImporterApp.Uploads
{
    public class UploadManager
    {
        private ILog log;
        private IDataService dataService;
        private readonly Queue<Tuple<string, List<DokuField>>> queue;

        public UploadManager()
        {
            log = LogManager.GetLogger(GetType());
            dataService = DataServiceFactory.Create();
            queue = new Queue<Tuple<string, List<DokuField>>>();
        }

        public bool Uploading { get; private set; }

        public string CommunityID { get; set; }
        public string FolderId { get; set; }
        public string DocumentaryID { get; set; }

        public void AddToUpload(Tuple<string, List<DokuField>> item)
        {
            queue.Enqueue(item);
        }

        public void CancelUploads()
        {
            Uploading = false;
            queue.Clear();
        }

        public async Task UploadFiles()
        {
            Uploading = true;

            var token = await Session.GetTikectAsync();

            if (string.IsNullOrWhiteSpace(token))
            {
                log.Error("No se pudo iniciar sesión en Dokuflex. Revise los parámetros de conexión y las credenciales de usuario");
                Uploading = false;
                return;
            }

            try
            {
                while (queue.Count > 0)
                {
                    var item = queue.Dequeue();

                    if (await UploadFile(token, item))
                    {

                    }
                }
            }
            finally
            {
                Uploading = false;
            }
        }

        private async Task<bool> UploadFile(string token, Tuple<string, List<DokuField>> item)
        {
            try
            {
                var result = await dataService.UploadAsync(token, CommunityID, string.Empty, FolderId, string.Empty,
                        string.Empty, true, string.Empty, string.Empty, false, new FileInfo(item.Item1));

                if (result != null)
                {
                    log.Info($"Successfully imported file: {item.Item1}");
                    await dataService.UpdateDocumentMetadataAsync(token, DocumentaryID, result.nodeId, item.Item2.ToArray());
                    log.Info($"Updated metadata for: {result.nodeId}");
                }
            }
            catch (Exception ex)
            {
                log.Error($"Can't import file: {item.Item1}", ex);
                return false;
            }

            return true;
        }
    }
}
