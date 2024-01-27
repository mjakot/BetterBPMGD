using BetterBPMGDCLI.Extensions;
using BetterBPMGDCLI.Models.Level;
using BetterBPMGDCLI.Models.Settings;
using BetterBPMGDCLI.Models.TimingProject;
using BetterBPMGDCLI.Utils;
using System.Xml.Linq;

namespace BetterBPMGDCLI.CLI
{
    public class CLIManager
    {
        private IPathSettings pathSettings;
        
        public Project CurrentTimingProject { get; }

        public CLIManager()
        {
            pathSettings = new PathSettings(); //TODO: get this from config manager? idk

            CurrentTimingProject = new(pathSettings);
        }

        public void NewTimingProject(string projectName, int songId, ulong songOffset = 0)
        {
            Project.CreateNew(pathSettings, projectName, songId, songOffset);
        }

        public void InjectToExisting(string levelKey)
        {
            XElement levels = XElement.Parse(FileUtility.HeavyReadFromFile(pathSettings.GeometryDashLevelsSavePath));

            XElement xmlLevel = levels.FindElementByKeyValue(levelKey, LocalLevel.DictionaryElementTag) ?? new("NotFound");

            LocalLevel level = LocalLevel.Parse(xmlLevel, levelKey);

            CurrentTimingProject.InjectTimings(level);

            xmlLevel = XElement.Parse(level.ToString() ?? "NotFound");

            FileUtility.HeavyWriteToFile(pathSettings.GeometryDashLevelsSavePath, levels.ToString(SaveOptions.DisableFormatting));
        }

        public void InjectToNew(string levelName)
        {
            XElement levels = XElement.Parse(FileUtility.HeavyReadFromFile(pathSettings.GeometryDashLevelsSavePath));

            LocalLevel level = LocalLevel.Parse(pathSettings.MinimalLevelPath, "k_-1"); // places level at the top of the list

            CurrentTimingProject.InjectTimings(level);

            levels.FindElementByKeyValue("k_0", LocalLevel.DictionaryElementTag)
                    ?.PreviousNode
                    ?.AddBeforeSelf(new XElement(LocalLevel.KeyElementTag, level.LevelKey));

            levels.FindElementByKeyValue(level.LevelKey, LocalLevel.KeyElementTag)
                    ?.AddAfterSelf(XElement.Parse(level.Encode()));

            FileUtility.HeavyWriteToFile(pathSettings.GeometryDashLevelsSavePath, levels.ToString(SaveOptions.DisableFormatting));
        }
    }
}
