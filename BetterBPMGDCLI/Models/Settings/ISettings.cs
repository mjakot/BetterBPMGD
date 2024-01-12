namespace BetterBPMGDCLI.Models.Settings
{
    public interface ISettings
    {
        void ResetAll();
        object GetDefault(string propertyName);
        string ToString();
    }
}
