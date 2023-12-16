namespace BetterBPMGDCLI.Models.Settings
{
    public interface ISettings
    {
        void ResetAll();

        string? GetDefault(string propertyName);
    }
}
