using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using log4net;
using FileImporterApp.FolderConfig;
using FileImporterApp.TextFiles;
using DokuFlex.WinForms.Common;
using System.Collections.Generic;
using DokuFlex.Windows.Common.Services.Data;
using FileImporterApp.Uploads;
using System.Diagnostics;

namespace FileImporterApp
{
    public class MyApplicationContext : ApplicationContext
    {
        private NotifyIcon notifyIcon;
        private ContextMenu contextMenu;
        private ImportFolderConfigManager folderConfigManager;
        private ImportTextManager ImportTextManager;
        private UploadManager uploadManager;
        private FileSystemWatcher watcher;
        private ILog log;

        public MyApplicationContext()
        {
            InitializeContext();
            ContextLoaded();

            Application.ThreadExit += Application_ThreadExit;
            Application.ThreadException += Application_ThreadException;
        }

        private void ContextLoaded()
        {
            if (Directory.Exists(folderConfigManager.FolderConfig.DirectoryPath))
            {
                StartWatch(folderConfigManager.FolderConfig.DirectoryPath);
            }
        }

        private void Application_ThreadExit(object sender, EventArgs e)
        {
            if (ImportTextManager.Importing)
                ImportTextManager.StopImport();
        }

        private void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            if (ImportTextManager.Importing)
                ImportTextManager.StopImport();

            log.Error("Application exception", e.Exception);
        }

        private void InitializeContext()
        {
            log = LogManager.GetLogger(GetType());

            folderConfigManager = new ImportFolderConfigManager();
            ImportTextManager = new ImportTextManager();
            uploadManager = new UploadManager();

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

            watcher = new FileSystemWatcher { Filter = "*.*" };
            watcher.Changed += Watcher_Changed;
        }

        private async void Watcher_Changed(object sender, FileSystemEventArgs e)
        {
            if (e.ChangeType == WatcherChangeTypes.Created)
            {
                var fileInfo = new FileInfo(e.FullPath);

                if (!folderConfigManager.FolderConfig.IsExtensionValid(fileInfo.Extension))
                    return;

                var dokuFields = folderConfigManager.FolderConfig.GetDokuFieldList(e.FullPath);
                var item = new Tuple<string, List<DokuField>>(e.FullPath, dokuFields);
                uploadManager.AddToUpload(item);

                if (!uploadManager.Uploading)
                    await uploadManager.UploadFiles();
            }
        }

        private void StartWatch(string path)
        {
            watcher.Path = path;
            watcher.EnableRaisingEvents = true;
        }

        private void StopWatch()
        {
            watcher.EnableRaisingEvents = false;
        }

        private void SettingsMenuItem_Click(object sender, EventArgs e)
        {
            using (var settingsForm = new SettingsForm())
            {
                settingsForm.ShowDialog();
            }
        }

        private void ChangeCredentialsMenuItem_Click(object sender, EventArgs e)
        {
            Session.ChangeCredentials();
        }

        private void ConfigureImportFolderMenuItem_Click(object sender, EventArgs e)
        {
            if (folderConfigManager.ShowConfigForm())
            {
                StopWatch();
                StartWatch(folderConfigManager.FolderConfig.DirectoryPath);
            }
        }

        private async void ImportFilesMenuItem_Click(object sender, EventArgs e)
        {
            if (ImportTextManager.Importing)
            {
                MessageBox.Show(Resources.ImportInProgressText, "FileImporter", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            await ImportTextManager.StartImport();
        }

        private void OpenImportFolderMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(folderConfigManager.FolderConfig.DirectoryPath);
        }

        private void ExitMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
