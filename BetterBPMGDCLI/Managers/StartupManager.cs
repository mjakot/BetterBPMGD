using BetterBPMGDCLI.Models.Settings;

namespace BetterBPMGDCLI.Managers
{
    public class StartupManager
    {
        public static WorkFlowManager Startup()
        {
            return new(ConfigManager.CreateInstance<PathSettings>());
        }
    }
}
