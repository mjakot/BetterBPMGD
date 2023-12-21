using BetterBPMGDCLI.Models.Settings.Interfaces;

namespace BetterBPMGDCLI.Models.Settings
{
    public class ControllerSettings : IControllerSettings
    {
        private static bool createNewLevelDefault = false;

        public bool CreateNewLevel { get; set; }

        public ControllerSettings()
        {
            CreateNewLevel = createNewLevelDefault;
        }

        public ControllerSettings(bool createNewLevel)
        {
            CreateNewLevel = createNewLevel;
        }

        public string? GetDefault(string propertyName)
        {
            string defaultName = propertyName + "Default";

            System.Reflection.FieldInfo? field = typeof(ControllerSettings).GetField(defaultName, System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);

            if (field is null) return null;

            return (string)(field.GetValue(this) ?? string.Empty);
        }

        public void ResetAll()
        {
            CreateNewLevel = createNewLevelDefault;
        }
    }
}
