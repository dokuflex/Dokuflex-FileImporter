using System;
using System.Drawing;
using System.Windows.Forms;
using log4net;
using FileImporterApp.FolderConfig;

namespace FileImporterApp
{
    class MyApplicationContext : ApplicationContext
    {
        private NotifyIcon notifyIcon;
        private ContextMenu contextMenu;
        private ImportFolderConfig folderConfig;
        private ImportFolderConfigManager folderConfigManager;
        private ILog log;

        public MyApplicationContext()
        {
            InitializeContext();
        }

        private void InitializeContext()
        {
            log = log = LogManager.GetLogger(GetType());

            folderConfigManager = new ImportFolderConfigManager();
            folderConfig = folderConfigManager.OpenConfiguration();

            contextMenu = new ContextMenu();

            var separator1MenuItem = new MenuItem { Text = "-" };

            var separator2MenuItem = new MenuItem { Text = "-" };

            var separator3MenuItem = new MenuItem { Text = "-" };

            var openImportFolderMenuItem = new MenuItem { Text = Resources.OpenImportFolderText };
            openImportFolderMenuItem.Click += OpenImportFolderMenuItem_Click;

            var importFilesMenuItem = new MenuItem { Text = Resources.ImportFilesText };
            importFilesMenuItem.Click += ImportFilesMenuItem_Click;

            var configureImportFolderMenuItem = new MenuItem { Text = Resources.ConfigureImportFolderText };
            configureImportFolderMenuItem.Click += ConfigureImportFolderMenuItem_Click;

            var changeCredentialsMenuItem = new MenuItem { Text = Resources.ChangeCredentialsText };
            changeCredentialsMenuItem.Click += ChangeCredentialsMenuItem_Click;

            var settingsMenuItem = new MenuItem { Text = Resources.SettingsText };
            settingsMenuItem.Click += SettingsMenuItem_Click;

            var exitMenuItem = new MenuItem { Text = Resources.ExitText };
            exitMenuItem.Click += ExitMenuItem_Click;

            contextMenu.MenuItems.AddRange(new MenuItem[]{openImportFolderMenuItem,
            importFilesMenuItem, separator1MenuItem, configureImportFolderMenuItem, settingsMenuItem,
            separator2MenuItem, changeCredentialsMenuItem, separator3MenuItem, exitMenuItem});

            notifyIcon = new NotifyIcon
            {
                ContextMenu = contextMenu,
                Text = "FileImporter",
                Icon = Icon.ExtractAssociatedIcon("FileImporterApp.ico"),
                Visible = true
            };
        }

        private void SettingsMenuItem_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ChangeCredentialsMenuItem_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ConfigureImportFolderMenuItem_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ImportFilesMenuItem_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void OpenImportFolderMenuItem_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ExitMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
