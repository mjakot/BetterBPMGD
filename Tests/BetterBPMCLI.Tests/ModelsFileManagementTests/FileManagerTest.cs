using BetterBPMGDCLI.Models.Settings.Interfaces;

namespace BetterBPMCLI.Tests.ModelsFileManagementTests
{
    public class FileManagerTest
    {
        [Fact]
        public void CreateNewProject_ValidInputs_EmptyProject()
        {

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

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
            public TestFileManagerSettings() => ResetAll();
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

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
                CurrentLevelPath = Path.Combine(CurrentLevelPath, "Level.xml");
                MinimalLevelPath = Path.Combine(CurrentLevelPath, "Minimal.xml");
                ProjectsFolderPath = Path.Combine(BetterBPMGDAppDataFolderPath, "Projects\\");
                BackupFolderPath = Path.Combine(GDFolderPath, "Backups\\");
                CreateLevelsBackup = true;
                AutoSongId = false;
            }
        }
    }
}
