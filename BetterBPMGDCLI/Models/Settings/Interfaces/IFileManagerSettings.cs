namespace BetterBPMGDCLI.Models.Settings.Interfaces
{
    public interface IFileManagerSettings : ISettings
    {
        string AppDataFolderPath { get; }
        string BetterBPMGDAppDataFolderPath { get; }
        string GDFolderPath { get; }
        string BetterBPMGDTemporaryFolderPath { get; }
        string BetterBPMGDLevelsSavesCopiesFolderPath { get; }
        string BetterBPMGDCurrentLevelFolderPath { get; }

        string GdLevelsSavePath { get; set; }
        string LocalLevelsCopyPath { get; set; }
        string DecryptedLocalLevelsCopyPath { get; set; }
        string CurrentLevelPath { get; set; }
        string MinimalLevelPath { get; set; }
        string ProjectsFolderPath { get; set; }
        string BackupFolderPath { get; set; }
        bool CreateLevelsBackup { get; set; }
        bool AutoSongId { get; set; }
    }
}
