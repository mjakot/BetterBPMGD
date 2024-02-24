using BetterBPMCLI.Tests.Context;
using BetterBPMCLI.Tests.LevelTests;
using BetterBPMGDCLI.Extensions;
using BetterBPMGDCLI.Models.Level;
using BetterBPMGDCLI.Models.Settings;
using BetterBPMGDCLI.Models.TimingProject;
using Common;
using System.Text;
using XUnitExtensions;
using BetterBPMGDCLI.Utils;

namespace BetterBPMCLI.Tests.TimingProjectTests
{
    public class ProjectTest
    {
        static int counter = 0;

        const string PROJECTNAME = "Test";

        [Fact]
        public void CreateNew_IPathSettings_Project_InitializesFilePaths()
        {
            string innerProjectName = $"{PROJECTNAME}{counter}";

            IPathSettings settings = new PathSettingsMock();

            File.Create(Path.Combine(settings.GeometryDashSavesFolderPath, $"{counter}.mp3")).Dispose();



            Project actual = Project.CreateNew(new BetterBPMGDCLI.Managers.ConfigManager(settings), innerProjectName, counter);



            Assert.True(Directory.Exists(settings.GetTimingProjectFolderPath(innerProjectName)));
            Assert.True(File.Exists(Path.Combine(settings.GetTimingProjectFolderPath(innerProjectName), $"{counter}.mp3")));
            Assert.True(File.Exists(settings.GetTimingListPath(innerProjectName)));
            Assert.True(File.Exists(settings.GetSongListPath(innerProjectName)));
            Assert.Equal(innerProjectName, actual.Name);
        }

        [Fact]
        public void SaveProject_FullProject_WritesToFilesSongsAndTiming()
        {
            string innerProjectName = $"{PROJECTNAME}{++counter}";

            IPathSettings settings = new PathSettingsMock();

            File.Create(Path.Combine(settings.GeometryDashSavesFolderPath, $"{counter}.mp3")).Dispose();

            Project project = Project.CreateNew(new BetterBPMGDCLI.Managers.ConfigManager(settings), innerProjectName, counter);

            Timing tTiming = new();

            Dictionary<int, ulong> song = new() { { counter, 0 } };

            project.AddTiming(tTiming);



            project.SaveProject();



            string expectedTimings = tTiming.Serialize();
            string expectedsSongs = new StringBuilder().AddDictionary(song, Constants.DefaultInnerSeparator).ToString();

            AssertExtension.EqualSkip(expectedTimings, File.ReadAllText(settings.GetTimingListPath(innerProjectName)).Replace(Environment.NewLine, string.Empty), [ 8 ]); // skip assertion at position 8. it's a counter value which is dependent on an instance.
            Assert.Equal(expectedsSongs, File.ReadAllText(settings.GetSongListPath(innerProjectName)));
        }

        [Fact]
        public void ReadProject_ProjectName_Project()
        {
            string innerProjectName = $"{PROJECTNAME}{++counter}";

            IPathSettings settings = new PathSettingsMock();

            File.Create(Path.Combine(settings.GeometryDashSavesFolderPath, $"{counter}.mp3")).Dispose();

            Project expected = Project.CreateNew(new BetterBPMGDCLI.Managers.ConfigManager(settings), innerProjectName, counter);

            Timing tTiming = new();

            expected.AddTiming(tTiming);

            expected.SaveProject();



            Project actual = Project.ReadProject(new BetterBPMGDCLI.Managers.ConfigManager(settings), innerProjectName);



            Assert.Equal(expected.Name, actual.Name);
            Assert.Equal(expected.SongIds[counter], actual.SongIds[counter]);
            Assert.Equal(expected.Timings[0].Bpm, actual.Timings[0].Bpm);
            Assert.Equal(expected.Timings[0].OffsetMS, actual.Timings[0].OffsetMS);
            Assert.Equal(expected.Timings[0].SubdivideBeats, actual.Timings[0].SubdivideBeats);
            Assert.Equal(expected.Timings[0].BeatSubdivision, actual.Timings[0].BeatSubdivision);
            Assert.Equal(expected.Timings[0].Speed, actual.Timings[0].Speed);
            Assert.Equal(expected.Timings[0].ColorPattern, actual.Timings[0].ColorPattern);
        }

        [Fact]
        public void InjectTimings_LocalLevel_CalculatesTimings()
        {
            LocalLevel level = LocalLevel.Parse(LocalLevelTest.MINIMALLOCALLEVEL, LocalLevelTest.LOCALLEVELKEY);

            string innerProjectName = $"{PROJECTNAME}{++counter}";

            IPathSettings settings = new PathSettingsMock();

            File.Copy(".\\AMONGUS.mp3", Path.Combine(settings.GeometryDashSavesFolderPath, $"{counter}.mp3"));

            Project project = Project.CreateNew(new BetterBPMGDCLI.Managers.ConfigManager(settings), innerProjectName, counter);

            Timing tTiming = new(0, 1, false, 0, SpeedPortalTypes.NORMAL, "ooo");

            project.AddTiming(tTiming);



            project.InjectTimings(level);



            Assert.NotEqual(level.LevelData?.Guidelines.Count, 0);
            Assert.Equal(level.LevelData?.Guidelines[0].OffsetMs, 0UL);
            Assert.Equal(level.LevelData?.Guidelines[0].GuidelineColor.GuidelineColor, 0.8);
        }
    }
}
