using BetterBPMGDCLI.Models.Settings;

namespace BetterBPMGDCLI.Managers.Configuration
{
    public class ConfigManager
    {
        public IPathSettings PathSettings { get; private set; }

        public ConfigManager(IPathSettings pathSettings)
        {
            PathSettings = pathSettings;
        }

        public void NotifySettingsChanged()
        {

        }
    }
}
