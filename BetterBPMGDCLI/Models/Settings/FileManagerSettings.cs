using BetterBPMGDCLI.Models.Settings.Interfaces;

namespace BetterBPMGDCLI.Models.Settings
{
    public class FileManagerSettings : IFileManagerSettings
    {
        public const string AppName = "BetterBPMGD\\";
        public const string GameName = "GeometryDash\\";
        public const string SaveFileName = "CCLocalLevels.dat";
        public const string TemporaryFolderName = "Temp\\";
        public const string SavesCopiesFolderName = "Copies\\";
        public const string CurrentFolderName = "Current\\";
        public const string ProjectsFolderName = "Projects\\";
        public string AppDataFolderPath => Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        public string BetterBPMGDAppDataFolderPath => Path.Combine(AppDataFolderPath, AppName);
        public string GDFolderPath => Path.Combine(AppDataFolderPath, GameName);
        public string BetterBPMGDTemporaryFolderPath => Path.Combine(AppDataFolderPath, TemporaryFolderName);
        public string BetterBPMGDLevelsSavesCopiesFolderPath => Path.Combine(AppDataFolderPath, SavesCopiesFolderName);
        public string BetterBPMGDCurrentLevelFolderPath => Path.Combine(AppDataFolderPath, CurrentFolderName);

        private string gdLevelsSavePathDefault => Path.Combine(GDFolderPath, SaveFileName);
        private string localsLevelsCopyPathDefault => Path.Combine(BetterBPMGDLevelsSavesCopiesFolderPath, "LocalLevelsCopy.dat");
        private string decryptedLocalsLevelsCopyPathDefault => Path.Combine(BetterBPMGDLevelsSavesCopiesFolderPath, "LocalLevelsCopy.xlm");
        private string currentLevelPathDefault => Path.Combine(BetterBPMGDCurrentLevelFolderPath, "Level.xml");
        private string minimalLevelPathDefault => Path.Combine(BetterBPMGDCurrentLevelFolderPath, "MinimalLevel.xml");
        private string projectsFolderPathDefault => Path.Combine(AppDataFolderPath, ProjectsFolderName);
        private string timingsListPathDefault => "Timings.txt";
        private string backupFolderPathDefault => Path.Combine(GDFolderPath, AppName + "Backups");
        private bool createLevelsBackupDefault => true;
        private bool autoSongIdDefault => true;

        public string GdLevelsSavePath { get; set; }
        public string LocalLevelsCopyPath { get; set; }
        public string DecryptedLocalLevelsCopyPath { get; set; }
        public string CurrentLevelPath { get; set; }
        public string MinimalLevelPath { get; set; }
        public string ProjectsFolderPath { get; set; }
        public string TimingsListPath { get; set; }
        public string BackupFolderPath { get; set; }
        public bool CreateLevelsBackup { get; set; }
        public bool AutoSongId { get; set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public FileManagerSettings() => ResetAll();
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        public FileManagerSettings(string gdLevelsSavePath, string localLevelsCopyPath, string decryptedLocalLevelPath, string currentLevelPath, string minimalLevelPath, string projectsFolderPath, string timingsListPath, string backupFolderPath, bool createLevelsBackup, bool autoSongId)
        {
            GdLevelsSavePath = gdLevelsSavePath;
            LocalLevelsCopyPath = localLevelsCopyPath;
            DecryptedLocalLevelsCopyPath = decryptedLocalLevelPath;
            CurrentLevelPath = currentLevelPath;
            MinimalLevelPath = minimalLevelPath;
            BackupFolderPath = backupFolderPath;
            ProjectsFolderPath = projectsFolderPath;
            TimingsListPath = timingsListPath;
            CreateLevelsBackup = createLevelsBackup;
            AutoSongId = autoSongId;
        }

        public string? GetDefault(string propertyName)
        {
            string defaultName = propertyName + "Default";

            System.Reflection.FieldInfo? field = typeof(FileManagerSettings).GetField(defaultName, System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);

            if (field is null) return null;

            return (string) (field.GetValue(this) ?? string.Empty);
        }

        public void ResetAll()
        {
            GdLevelsSavePath = gdLevelsSavePathDefault;
            LocalLevelsCopyPath = localsLevelsCopyPathDefault;
            DecryptedLocalLevelsCopyPath = decryptedLocalsLevelsCopyPathDefault;
            CurrentLevelPath = currentLevelPathDefault;
            MinimalLevelPath = minimalLevelPathDefault;
            BackupFolderPath = backupFolderPathDefault;
            ProjectsFolderPath = projectsFolderPathDefault;
            TimingsListPath = timingsListPathDefault;
            CreateLevelsBackup = createLevelsBackupDefault;
            AutoSongId = autoSongIdDefault;
        }
    }
}
