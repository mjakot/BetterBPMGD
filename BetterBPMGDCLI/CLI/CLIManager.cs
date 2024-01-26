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

        public void InjectTimings(string levelKey)
        {
            XElement levels = XElement.Parse(FileUtility.HeavyReadFromFile(pathSettings.GeometryDashLevelsSavePath));

            LocalLevel level = LocalLevel.Parse(levels.FindElementByKeyValue(levelKey, "d") ?? new("NotFound"), levelKey);

            CurrentTimingProject.InjectTimings(level);
        }
    }
}
