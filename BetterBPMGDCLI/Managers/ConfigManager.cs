using BetterBPMGDCLI.Extensions;
using BetterBPMGDCLI.Models.Settings;
using BetterBPMGDCLI.Utils;
using System.ComponentModel;

namespace BetterBPMGDCLI.Managers
{
    public class ConfigManager : INotifyPropertyChanged
    {
        public IPathSettings PathSettings { get; private set; }

        public event PropertyChangedEventHandler? PropertyChanged;

        public ConfigManager()
        {
            PathSettings = ReadSettings<PathSettings>(Path.Combine(new PathSettings().BetterBPMGDSettingsFolderPath, Path.ChangeExtension(nameof(PathSettings), Constants.TXTExtension)));
        }

        ~ConfigManager() => SaveSettings(nameof(PathSettings));

        public static ConfigManager CreateInstance<PathSettingsType>() where PathSettingsType : SettingsBase, IPathSettings, new() => new ConfigManager() { PathSettings = ReadSettings<PathSettingsType>(nameof(PathSettings)) };

        public void PathSettingsChanged()
        {
            SaveSettings(nameof(PathSettings));

            OnPropertyChanged(nameof(PathSettings));
        }

        protected void OnPropertyChanged(PropertyChangedEventArgs e) => PropertyChanged?.Invoke(this, e);

        protected void OnPropertyChanged(string propertyName) => OnPropertyChanged(new PropertyChangedEventArgs(propertyName));

        private void SaveSettings(string settingsName) => FileUtility.WriteToFile(Path.Combine(PathSettings.BetterBPMGDSettingsFolderPath, Path.ChangeExtension(settingsName, Constants.TXTExtension)), GetType().GetProperty(settingsName)?.GetValue(this, null).Serialize(false) ?? string.Empty);
        private static T ReadSettings<T>(string settingsPath) where T : ISettings, new() => FileUtility.ReadFromFile(settingsPath).Desirialize<T>(false);
    }
}
