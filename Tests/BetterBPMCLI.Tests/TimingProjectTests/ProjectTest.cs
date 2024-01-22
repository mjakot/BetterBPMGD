using BetterBPMCLI.Tests.Context;
using BetterBPMGDCLI.Models.Settings;
using BetterBPMGDCLI.Models.TimingProject;

namespace BetterBPMCLI.Tests.TimingProjectTests
{
    public class ProjectTest
    {
        static int counter = 0;

        const string PROJECTNAME = "Test";

        [Fact]
        public void CreateNew_IPathSettings_Project_InitializesFilePaths()
        {
            string innerProjectName = $"{PROJECTNAME}{counter++}";

            IPathSettings setting = new PathSettingsMock();

            File.Create(Path.Combine(setting.GeometryDashSavesFolderPath, "0.mp3")).Dispose();



            Project actual = Project.CreateNew(setting, innerProjectName, 0);



            Assert.True(Directory.Exists(setting.GetTimingProjectFolderPath(innerProjectName)));
            Assert.True(File.Exists(Path.Combine(setting.GetTimingProjectFolderPath(innerProjectName), "0.mp3")));
            Assert.True(File.Exists(setting.GetTimingListPath(innerProjectName)));
            Assert.True(File.Exists(setting.GetSongListPath(innerProjectName)));
        }
    }
}
