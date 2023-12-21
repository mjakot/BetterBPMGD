using BetterBPMGDCLI.Models.Settings.Interfaces;

namespace BetterBPMGDCLI.Models.Settings
{
    public class FileManagerSettings : IFileManagerSettings
    {
        public const string AppName = "BetterBPMGD";
        public const string GameName = "GeometryDash";
        public const string SaveFileName = "CCLocalLevels.dat";
        public const string TemporaryFolderName = "Temp";
        public const string SavesCopiesFolderName = "Copies";
        public const string CurrentFolderName = "Current";
        public static string AppDataFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        public static string BetterBPMGDAppDataFolderPath = Path.Combine(AppDataFolderPath, AppName);
        public static string GDFolderPath = Path.Combine(AppDataFolderPath, GameName);
        public static string BetterBPMGDTemporaryFolderPath = Path.Combine(AppDataFolderPath, TemporaryFolderName);
        public static string BetterBPMGDLevelsSavesCopiesFolderPath = Path.Combine(AppDataFolderPath, SavesCopiesFolderName);
        public static string BetterBPMGDCurrentLevelFolderPath = Path.Combine(AppDataFolderPath, CurrentFolderName);

        private static string gdLevelsSavePathDefault = Path.Combine(GDFolderPath, SaveFileName);
        private static string localsLevelsCopyPathDefault = Path.Combine(BetterBPMGDLevelsSavesCopiesFolderPath, "LocalLevelsCopy.dat");
        private static string decryptedLocalsLevelsCopyPathDefault = Path.Combine(BetterBPMGDLevelsSavesCopiesFolderPath, "LocalLevelsCopy.xlm");
        private static string currentLevelPathDefault = Path.Combine(BetterBPMGDCurrentLevelFolderPath, "Level.xml");
        private static string minimalLevelPathDefault = Path.Combine(BetterBPMGDCurrentLevelFolderPath, "MinimalLevel.xml");
        private static string backupFolderPathDefault = Path.Combine(GDFolderPath, AppName + "Backups");
        private static bool createLevelsBackupDefault = true;

        public string GdLevelsSavePath { get; set; }
        public string LocalLevelsCopyPath { get; set; }
        public string DecryptedLocalLevelsCopyPath { get; set; }
        public string CurrentLevelPath { get; set; }
        public string MinimalLevelPath { get; set; }
        public string BackupFolderPath { get; set; }
        public bool CreateLevelsBackup { get; set; }

        public FileManagerSettings()
        {
            GdLevelsSavePath = gdLevelsSavePathDefault;
            LocalLevelsCopyPath = localsLevelsCopyPathDefault;
            DecryptedLocalLevelsCopyPath = decryptedLocalsLevelsCopyPathDefault;
            CurrentLevelPath = currentLevelPathDefault;
            MinimalLevelPath = minimalLevelPathDefault;
            BackupFolderPath = backupFolderPathDefault;
            CreateLevelsBackup = createLevelsBackupDefault;
        }

        public FileManagerSettings(string gdLevelsSavePath, string localLevelsCopyPath, string decryptedLocalLevelPath, string currentLevelPath, string minimalLevelPath, string backupFolderPath, bool createLevelsBackup)
        {
            GdLevelsSavePath = gdLevelsSavePath;
            LocalLevelsCopyPath = localLevelsCopyPath;
            DecryptedLocalLevelsCopyPath = decryptedLocalLevelPath;
            CurrentLevelPath = currentLevelPath;
            MinimalLevelPath = minimalLevelPath;
            BackupFolderPath = backupFolderPath;
            CreateLevelsBackup = createLevelsBackup;
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
            CreateLevelsBackup = CreateLevelsBackup;
        }
    }
}
