namespace BetterBPMGDCLI.Models.Settings
{
    public interface ISettings
    {
        string DefaultLevelsSavePath { get; }
        string LevelsSavePath { get; set; }

        string DefaultCachePath { get; }
        string CachePath { get; set; }

        void ResetAllSettings();
    }
}
