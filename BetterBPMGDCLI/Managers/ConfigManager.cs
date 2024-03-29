﻿using BetterBPMGDCLI.Extensions;
using BetterBPMGDCLI.Models.Settings;
using BetterBPMGDCLI.Utils;
using System.ComponentModel;

namespace BetterBPMGDCLI.Managers
{
    public class ConfigManager : INotifyPropertyChanged, IDisposable
    {
        public IPathSettings PathSettings { get; private set; }

        public event PropertyChangedEventHandler? PropertyChanged;

        public ConfigManager() : this(new PathSettings()) { }

        public ConfigManager(IPathSettings pathSettings) => PathSettings = pathSettings;

        public static ConfigManager CreateInstance<PathSettingsType>() where PathSettingsType : SettingsBase, IPathSettings, new()
        {
            IPathSettings pathSettings;

            try
            {
                pathSettings = ReadSettings<PathSettingsType>(Models.Settings.PathSettings.GetSerializationPath(new PathSettingsType()));
            }
            catch (Exception)
            {
                pathSettings = new PathSettings();
            }

            return new ConfigManager(pathSettings);
        }

        public void Dispose()
        {
            SaveSettings(PathSettings);

            GC.SuppressFinalize(this);
        }

        public void PathSettingsChanged()
        {
            SaveSettings(PathSettings);

            OnPropertyChanged(nameof(PathSettings));
        }

        protected void OnPropertyChanged(PropertyChangedEventArgs e) => PropertyChanged?.Invoke(this, e);

        protected void OnPropertyChanged(string propertyName) => OnPropertyChanged(new PropertyChangedEventArgs(propertyName));

        private void SaveSettings<T>(T settings) where T : ISettings
            => FileUtility.HeavyWriteToFile(Path.Combine(PathSettings.SettingsFolderPath, Path.ChangeExtension(typeof(T).Name, Constants.TXTExtension)),
                                             settings.Serialize(false));

        private static T ReadSettings<T>(string settingsPath) where T : SettingsBase, ISettings, new() => File.ReadAllText(settingsPath).Desirialize<T>(false);
    }
}
