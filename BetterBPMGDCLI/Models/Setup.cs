using BetterBPMGDCLI.Models.Settings;
using BetterBPMGDCLI.Models.Settings.Interfaces;
using System.Text;

namespace BetterBPMGDCLI.Models
{
    public static class Setup
    {
        private const string MinimalLevelInitialPath = ".\\MinimalLevel.xml";
        private const string ConfigPath = ".config";

        private static IFileManagerSettings? fileManagerSettings;
        private static IControllerSettings? controllerSettings;

        public static Controller GetController()
        {
            fileManagerSettings = new FileManagerSettings();
            controllerSettings = new ControllerSettings();

            return new(fileManagerSettings, controllerSettings);
        }

        private static bool SetupFiles()
        {
            if (fileManagerSettings is null || controllerSettings is null) return false;
            if (Directory.Exists(fileManagerSettings.BetterBPMGDAppDataFolderPath)) return true;

            Directory.CreateDirectory(fileManagerSettings.BetterBPMGDAppDataFolderPath);
            Directory.CreateDirectory(fileManagerSettings.ProjectsFolderPath);
            Directory.CreateDirectory(fileManagerSettings.BackupFolderPath);
            Directory.CreateDirectory(fileManagerSettings.BetterBPMGDCurrentLevelFolderPath);
            Directory.CreateDirectory(fileManagerSettings.BetterBPMGDLevelsSavesCopiesFolderPath);
            Directory.CreateDirectory(fileManagerSettings.BetterBPMGDTemporaryFolderPath);
            Directory.CreateDirectory(Path.Combine(fileManagerSettings.BetterBPMGDAppDataFolderPath, ConfigPath));

            if (!File.Exists(MinimalLevelInitialPath)) return false;

            using (FileStream fs = File.Create(fileManagerSettings.MinimalLevelPath))
            {
                byte[] minimalLevelBytes = Encoding.UTF8.GetBytes(File.ReadAllText(MinimalLevelInitialPath));

                fs.Write(minimalLevelBytes, 0, minimalLevelBytes.Length);
            }


        }

        private static void GetSettings()
        {
            if (fileManagerSettings is null || controllerSettings is null) return;
        }
    }
}