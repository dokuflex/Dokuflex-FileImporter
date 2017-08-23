using System.Drawing;
using System.Windows.Forms;

namespace FileImporterApp
{
    class MyApplicationContext : ApplicationContext
    {
        private NotifyIcon notifyIcon;
        private ContextMenu contextMenu;

        public MyApplicationContext()
        {
            InitializeContext();
        }

        private void InitializeContext()
        {
            contextMenu = new ContextMenu();

            notifyIcon = new NotifyIcon
            {
                ContextMenu = contextMenu,
                Text = "FileImporter",
                Icon = Icon.ExtractAssociatedIcon("FileImporterApp.ico"),
                Visible = true
            };
        }
    }
}
