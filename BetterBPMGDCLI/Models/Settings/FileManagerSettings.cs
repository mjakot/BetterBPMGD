namespace BetterBPMGDCLI.Models.Settings
{
    public class FileManagerSettings : IFileManagerSettings
    {
        private static string appName = "BetterBPMGD";
        private static string appDataFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        private static string BetterBPMGDAppDataFolderPath = Path.Combine(appDataFolderPath, appName);

        private static string GdLevelsSavePathDefault = Path.Combine(appDataFolderPath, "GeometryDash");
        private static string LocalsLevelsCopyPathDefault = Path.Combine(BetterBPMGDAppDataFolderPath, "SaveCopy");
        private static string TemporaryLevelPathDefault = Path.Combine(BetterBPMGDAppDataFolderPath, "Temp");

        public string GdLevelsSavePath { get; set; }
        public string LocalsLevelsCopyPath { get; set; }
        public string TemporaryLevelPath { get; set; }

        public FileManagerSettings()
        {
            GdLevelsSavePath = string.Empty;
            LocalsLevelsCopyPath = string.Empty;
            TemporaryLevelPath = string.Empty;
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
            GdLevelsSavePath = GdLevelsSavePathDefault;
            LocalsLevelsCopyPath = LocalsLevelsCopyPathDefault;
            TemporaryLevelPath = TemporaryLevelPathDefault;
        }
    }
}
