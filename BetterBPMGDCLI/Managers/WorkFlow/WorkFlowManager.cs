using BetterBPMGDCLI.Extensions;
using BetterBPMGDCLI.Models.Level;
using BetterBPMGDCLI.Models.Settings;
using BetterBPMGDCLI.Models.TimingProject;
using BetterBPMGDCLI.Utils;
using System.Xml.Linq;

namespace BetterBPMGDCLI.Managers
{
    public class WorkFlowManager
    {
        private ConfigManager configManager;
        private IPathSettings pathSettings;

        public Project CurrentTimingProject { get; private set; }

        public WorkFlowManager(ConfigManager configManager)
        {
            this.configManager = configManager;
            pathSettings = configManager.PathSettings;

            configManager.PropertyChanged += ConfigManager_PropertyChanged;

            CurrentTimingProject = new(configManager);
        }

        public void NewTimingProject(string projectName, int songId, ulong songOffset = 0)
        {
            CurrentTimingProject = Project.CreateNew(configManager, projectName, songId, songOffset);
        }

        public void ReadExistingTimingProject(string projectName)
        {
            CurrentTimingProject = Project.ReadProject(configManager, projectName);
        }

        public IReadOnlyList<LevelPreview?>? FindLevelsByName(string levelName)
        {
            XElement levels = XElement.Parse(FileUtility.HeavyReadFromFile(pathSettings.GeometryDashLevelsSavePath));

            return levels.FindAllLevelsByName(levelName) as IReadOnlyList<LevelPreview?>;
        }

        public void InjectToExisting(string levelKey)
        {
            XElement levels = XElement.Parse(FileUtility.HeavyReadFromFile(pathSettings.GeometryDashLevelsSavePath));

            XElement xmlLevel = levels.FindElementByKeyValue(levelKey, Constants.DictionaryElementTag) ?? new(Constants.NotFoundPlaceholder);

            LocalLevel level = LocalLevel.Parse(xmlLevel, levelKey);

            CurrentTimingProject.InjectTimings(level);

            xmlLevel = XElement.Parse(level.ToString() ?? Constants.NotFoundPlaceholder);

            FileUtility.HeavyWriteToFile(pathSettings.GeometryDashLevelsSavePath, levels.ToString(SaveOptions.DisableFormatting));
        }

        public void InjectToNew(string levelName)
        {
            XElement levels = XElement.Parse(FileUtility.HeavyReadFromFile(pathSettings.GeometryDashLevelsSavePath));

            LocalLevel level = LocalLevel.Parse(pathSettings.MinimalLevelPath, Constants.AboveAllLevelsKey); // places level at the top of the list

            CurrentTimingProject.InjectTimings(level);

            levels.FindElementByKeyValue(Constants.FirstLevelKey, Constants.DictionaryElementTag)
                    ?.PreviousNode
                    ?.AddBeforeSelf(new XElement(Constants.KeyElementTag, level.LevelKey));

            levels.FindElementByKeyValue(level.LevelKey, Constants.KeyElementTag)
                    ?.AddAfterSelf(XElement.Parse(level.Encode()));

            FileUtility.HeavyWriteToFile(pathSettings.GeometryDashLevelsSavePath, levels.ToString(SaveOptions.DisableFormatting));
        }

        private void ConfigManager_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(configManager.PathSettings))
                pathSettings = configManager.PathSettings;
        }
    }
}
