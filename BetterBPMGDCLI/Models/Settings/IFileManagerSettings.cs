namespace BetterBPMGDCLI.Models.Settings
{
    public interface IFileManagerSettings : ISettings
    {
        string GdLevelsSavePath { get; set; }
        string LocalsLevelsCopyPath { get; set; }
        string TemporaryLevelPath { get; set; }
    }
}
