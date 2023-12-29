namespace BetterBPMGDCLI.Models.Settings.Interfaces
{
    public interface ISettings
    {
        void ResetAll();

        string? GetDefault(string propertyName);
    }
}
