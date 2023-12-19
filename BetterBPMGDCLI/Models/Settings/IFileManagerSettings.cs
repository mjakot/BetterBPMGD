namespace BetterBPMGDCLI.Models.Settings
{
    public interface IFileManagerSettings : ISettings
    {
        string GdLevelsSavePath { get; set; }
        string LocalLevelsCopyPath { get; set; }
        string DecryptedLocalLevelsCopyPath { get; set; }
        string TemporaryLevelPath { get; set; }
        string BackupFolderPath { get; set; }
        bool CreateLevelsBackup { get; set; }
    }
}
