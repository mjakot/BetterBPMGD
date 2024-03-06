using BetterBPMGDCLI.Extensions;
using BetterBPMGDCLI.Models.Ciphers;
using BetterBPMGDCLI.Models.Level;
using BetterBPMGDCLI.Models.Settings;
using BetterBPMGDCLI.Models.TimingProject;
using BetterBPMGDCLI.Utils;
using System.Xml.Linq;

namespace BetterBPMGDCLI.Managers
{
    public class WorkFlowManager : IDisposable
    {
        private LocalLevelsCipher? localLevelCipher;
        
        private IPathSettings pathSettings;

        public ConfigManager ConfigManager { get; private set; }
        public Project CurrentTimingProject { get; private set; }

        public WorkFlowManager(ConfigManager configManager)
        {
            ConfigManager = configManager;
            pathSettings = configManager.PathSettings;

            configManager.PropertyChanged += ConfigManagerPropertyChanged;

            string currentProjectName = Guid.NewGuid().ToString();

            if (File.Exists(pathSettings.CurrentProjectSaveFilePath))
                currentProjectName = FileUtility.ReadFromFile(pathSettings.CurrentProjectSaveFilePath);

            if (Directory.Exists(Path.Combine(pathSettings.TimingProjectsFolderPath, currentProjectName))) //TODO: check this somewhere else
                    CurrentTimingProject = Project.ReadProject(ConfigManager, currentProjectName);
            else
                CurrentTimingProject = new(configManager);

            DecodeLocalLevels();
        }

        public void Dispose()
        {
            if (!string.IsNullOrEmpty(CurrentTimingProject.Name))
                FileUtility.WriteToFile(pathSettings.CurrentProjectSaveFilePath, CurrentTimingProject.Name);

            CurrentTimingProject.Dispose();
            ConfigManager.Dispose();

            GC.SuppressFinalize(this);
        }

        public void NewTimingProject(string projectName, int songId, ulong songOffset = 0)
        {
            CurrentTimingProject = Project.CreateNew(ConfigManager, projectName, songId, songOffset);
        }

        public void ReadExistingTimingProject(string projectName)
        {
            if (projectName == CurrentTimingProject.Name) return;

            CurrentTimingProject.Dispose();

            CurrentTimingProject = Project.ReadProject(ConfigManager, projectName);
        }

        public IEnumerable<LevelPreview?> FindLevelsByName(string levelName, bool ignoreCase)
        {
            XElement levels = XElement.Parse(FileUtility.HeavyReadFromFile(pathSettings.GeometryDashLevelsSavePath));

            return levels.FindAllLevelsByName(levelName, ignoreCase);
        }

        public void InjectToExisting(string levelKey)
        {
            XElement levels = XElement.Parse(FileUtility.HeavyReadFromFile(pathSettings.GeometryDashLevelsSavePath));

            XElement xmlLevel = levels.FindElementByKeyValue(levelKey, Constants.DictionaryElementTag) ?? new(Constants.NotFoundPlaceholder);

            LocalLevel level = LocalLevel.Parse(xmlLevel, levelKey);

            CurrentTimingProject.InjectTimings(level);

            xmlLevel = XElement.Parse(level.Encode() ?? Constants.NotFoundPlaceholder);

            FileUtility.HeavyWriteToFile(pathSettings.GeometryDashLevelsSavePath, Constants.GDXMLDeclaration + levels.ToString(SaveOptions.DisableFormatting));
        }

        public void InjectToNew(string levelName)
        {
            XElement levels = XElement.Parse(FileUtility.HeavyReadFromFile(pathSettings.GeometryDashLevelsSavePath));

            LocalLevel level = LocalLevel.Parse(pathSettings.MinimalLevelPath, Constants.LevelsOnTopKey); // places level at the top of the list

            level.LevelName = levelName;

            CurrentTimingProject.InjectTimings(level);

            levels.FindElementByKeyValue(Constants.FirstLevelKey, Constants.DictionaryElementTag)
                    ?.PreviousNode
                    ?.AddBeforeSelf(new XElement(Constants.KeyElementTag, level.LevelKey));

            levels.FindElementByKeyValue(level.LevelKey, Constants.KeyElementTag)
                    ?.AddBeforeSelf(XElement.Parse(level.Encode()));

            FileUtility.HeavyWriteToFile(pathSettings.GeometryDashLevelsSavePath, Constants.GDXMLDeclaration + levels.ToString(SaveOptions.DisableFormatting));
        }

        public void BackupLocalLevels()
            => FileUtility.CopyFile(pathSettings.GeometryDashLevelsSavePath, Path.Combine(pathSettings.BackupFolderPath,
                                        $"CCLocalLevels_Backup_{DateTime.Now:gg_MM_dd_yy-hh_mm_ss_fff}{Constants.TXTExtension}"));

        private void ConfigManagerPropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(ConfigManager.PathSettings))
                pathSettings = ConfigManager.PathSettings;
        }

        private void DecodeLocalLevels()
        {
            BackupLocalLevels();

            localLevelCipher = new(FileUtility.HeavyReadFromFile(pathSettings.GeometryDashLevelsSavePath));

            FileUtility.HeavyWriteToFile(pathSettings.GeometryDashLevelsSavePath, localLevelCipher.Decode());
        }
    }
}
