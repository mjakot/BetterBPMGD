using BetterBPMGDCLI.Models.FileManagement;
using BetterBPMGDCLI.Models.Settings.Interfaces;

namespace BetterBPMCLI.Tests.ModelsFileManagementTests
{
    public class FileManagerTest
    {
        [Fact]
        public void CreateNewProject_ValidInputs_EmptyProject()
        {
            IFileManagerSettings settings = SetupFileSystem();

            FileStream fs = File.Create(Path.Combine(settings.GDFolderPath, "0.mp3"));
            fs.Dispose();

            FileManager manager = new FileManager(settings);

            string projectname = "test";
            string expectedDirectory = Path.Combine(settings.ProjectsFolderPath, "test");
            string expectedAudio = Path.Combine(expectedDirectory, "0.mp3");

            ulong songId = 0;



            bool created = manager.CreateNewProject(projectname, songId);


            

            Assert.True(created);
            Assert.True(Directory.Exists(expectedDirectory));
            Assert.True(File.Exists(expectedAudio));
        }

        private IFileManagerSettings SetupFileSystem()
        {
            IFileManagerSettings settings = new TestFileManagerSettings();

            Directory.CreateDirectory(settings.AppDataFolderPath);
            Directory.CreateDirectory(settings.BetterBPMGDAppDataFolderPath);
            Directory.CreateDirectory(settings.GDFolderPath);
            Directory.CreateDirectory(settings.BetterBPMGDTemporaryFolderPath);
            Directory.CreateDirectory(settings.BetterBPMGDLevelsSavesCopiesFolderPath);
            Directory.CreateDirectory(settings.BetterBPMGDCurrentLevelFolderPath);
            Directory.CreateDirectory(settings.ProjectsFolderPath);
            Directory.CreateDirectory(settings.BackupFolderPath);

            File.Create(settings.GdLevelsSavePath);
            File.Create(settings.LocalLevelsCopyPath);
            File.Create(settings.DecryptedLocalLevelsCopyPath);
            File.Create(settings.CurrentLevelPath);
            File.Create(settings.MinimalLevelPath);

            return settings;
        }

        private class TestFileManagerSettings : IFileManagerSettings
        {
            public string AppDataFolderPath => "c:\\BetterBPMTest\\";

            public string BetterBPMGDAppDataFolderPath => Path.Combine(AppDataFolderPath, "BetterBPMProgram\\");

            public string GDFolderPath => Path.Combine(AppDataFolderPath, "GDProgram\\");

            public string BetterBPMGDTemporaryFolderPath => Path.Combine(BetterBPMGDAppDataFolderPath, "Temp\\");

            public string BetterBPMGDLevelsSavesCopiesFolderPath => Path.Combine(BetterBPMGDAppDataFolderPath, "Copies\\");

            public string BetterBPMGDCurrentLevelFolderPath => Path.Combine(BetterBPMGDAppDataFolderPath, "Current\\");

            public string GdLevelsSavePath { get; set; }
            public string LocalLevelsCopyPath { get; set; }
            public string DecryptedLocalLevelsCopyPath { get; set; }
            public string CurrentLevelPath { get; set; }
            public string MinimalLevelPath { get; set; }
            public string ProjectsFolderPath { get; set; }
            public string BackupFolderPath { get; set; }
            public bool CreateLevelsBackup { get; set; }
            public bool AutoSongId { get; set; }

            public TestFileManagerSettings() => ResetAll();

            public TestFileManagerSettings(string gdLevelsSavePath, string localLevelsCopyPath, string decryptedLocalLevelsCopyPath, string currentLevelPath, string minimalLevelPath, string projectsFolderPath, string backupFolderPath, bool createLevelsBackup, bool autoSongId)
            {
                GdLevelsSavePath = gdLevelsSavePath;
                LocalLevelsCopyPath = localLevelsCopyPath;
                DecryptedLocalLevelsCopyPath = decryptedLocalLevelsCopyPath;
                CurrentLevelPath = currentLevelPath;
                MinimalLevelPath = minimalLevelPath;
                ProjectsFolderPath = projectsFolderPath;
                BackupFolderPath = backupFolderPath;
                CreateLevelsBackup = createLevelsBackup;
                AutoSongId = autoSongId;
            }

            public string? GetDefault(string propertyName)
            {
                throw new NotImplementedException();
            }

            public void ResetAll()
            {
                GdLevelsSavePath = Path.Combine(GDFolderPath, "Levels.dat");
                LocalLevelsCopyPath = Path.Combine(BetterBPMGDLevelsSavesCopiesFolderPath, "LevelsCopy.dat");
                DecryptedLocalLevelsCopyPath = Path.Combine(BetterBPMGDLevelsSavesCopiesFolderPath, "LevelsCopy.xml");
                CurrentLevelPath = Path.Combine(BetterBPMGDCurrentLevelFolderPath, "Level.xml");
                MinimalLevelPath = Path.Combine(BetterBPMGDCurrentLevelFolderPath, "Minimal.xml");
                ProjectsFolderPath = Path.Combine(BetterBPMGDAppDataFolderPath, "Projects\\");
                BackupFolderPath = Path.Combine(GDFolderPath, "Backups\\");
                CreateLevelsBackup = true;
                AutoSongId = false;
            }
        }
    }
}
