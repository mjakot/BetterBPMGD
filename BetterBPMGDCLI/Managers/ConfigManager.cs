﻿using BetterBPMGDCLI.Extensions;
using BetterBPMGDCLI.Models.Settings;
using BetterBPMGDCLI.Utils;
using System.ComponentModel;
using System.Reflection;

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
            SaveSettings(nameof(PathSettings));
        }

        public void PathSettingsChanged()
        {
            SaveSettings(nameof(PathSettings));

            OnPropertyChanged(nameof(PathSettings));
        }

        protected void OnPropertyChanged(PropertyChangedEventArgs e) => PropertyChanged?.Invoke(this, e);

        protected void OnPropertyChanged(string propertyName) => OnPropertyChanged(new PropertyChangedEventArgs(propertyName));

        private void SaveSettings(string settingsName)
        {
            Type type = GetType();
            PropertyInfo? propertyInfo = type.GetProperty(settingsName);
            object? propertyValue = propertyInfo?.GetValue(this, null);
            string temp = propertyValue.Serialize(false) ?? string.Empty;

            FileUtility.WriteToFile(Path.Combine(PathSettings.BetterBPMGDSettingsFolderPath, Path.ChangeExtension(settingsName, Constants.TXTExtension)), temp);
        }

        private static T ReadSettings<T>(string settingsPath) where T : ISettings, new() => FileUtility.ReadFromFile(settingsPath).Desirialize<T>(false);
    }
}
