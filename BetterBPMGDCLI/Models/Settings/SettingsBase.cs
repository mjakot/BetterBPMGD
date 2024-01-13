namespace BetterBPMGDCLI.Models.Settings
{
    public abstract class SettingsBase : ISettings
    {
        public abstract object GetDefault(string propertyName);
        public abstract void ResetAll();
        public abstract override string ToString();
        public static SettingsBase FromString(string settings) => null;
    }
}
