using BetterBPMGDCLI.Extensions;
using BetterBPMGDCLI.Models.Settings;
using BetterBPMGDCLI.Utils;
using System.ComponentModel;

namespace BetterBPMGDCLI.Managers
{
    public class ConfigManager : INotifyPropertyChanged, IDisposable
    {
        public IPathSettings PathSettings { get; private set; }

        public event PropertyChangedEventHandler? PropertyChanged;

        public ConfigManager() : this(ReadSettings<PathSettings>(Path.Combine((string)new PathSettings().GetDefault(nameof(PathSettings.BetterBPMGDSettingsFolderPath)), Path.ChangeExtension(nameof(PathSettings), Constants.TXTExtension)))) { }

        public ConfigManager(IPathSettings pathSettings) => PathSettings = pathSettings;

        ~ConfigManager() => Dispose();

        public static ConfigManager CreateInstance<PathSettingsType>() where PathSettingsType : SettingsBase, IPathSettings, new()
        {
            IPathSettings pathSettings;

            try
            {
                pathSettings = ReadSettings<PathSettingsType>(nameof(PathSettings));
            }
            catch (Exception)
            {
                pathSettings = new PathSettings();
            }

            return new ConfigManager() { PathSettings = pathSettings };
        }

        public void Dispose()
        {
            SaveSettings(PathSettings);
        }

        public void PathSettingsChanged()
        {
            SaveSettings(PathSettings);

            OnPropertyChanged(nameof(PathSettings));
        }

        protected void OnPropertyChanged(PropertyChangedEventArgs e) => PropertyChanged?.Invoke(this, e);

        protected void OnPropertyChanged(string propertyName) => OnPropertyChanged(new PropertyChangedEventArgs(propertyName));

        private void SaveSettings<T>(T settings) where T : ISettings => FileUtility.WriteToFile(Path.Combine(PathSettings.BetterBPMGDSettingsFolderPath, Path.ChangeExtension(typeof(T).Name, Constants.TXTExtension)), settings.Serialize(false));

        private static T ReadSettings<T>(string settingsPath) where T : SettingsBase, ISettings, new() => FileUtility.ReadFromFile(settingsPath).Desirialize<T>(false);
    }
}
