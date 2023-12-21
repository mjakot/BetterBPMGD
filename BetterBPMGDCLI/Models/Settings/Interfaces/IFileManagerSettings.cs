namespace BetterBPMGDCLI.Models.Settings.Interfaces
{
    public interface IFileManagerSettings : ISettings
    {
        string GdLevelsSavePath { get; set; }
        string LocalLevelsCopyPath { get; set; }
        string DecryptedLocalLevelsCopyPath { get; set; }
        string CurrentLevelPath { get; set; }
        string MinimalLevelPath { get; set; }
        string BackupFolderPath { get; set; }
        bool CreateLevelsBackup { get; set; }
    }
}
