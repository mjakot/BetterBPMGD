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

            File.Create();



            Project actual = Project.CreateNew(setting, innerProjectName, 0);



            Assert.True(Directory.Exists(setting.GetTimingProjectFolderPath(innerProjectName)));
        }
    }
}
