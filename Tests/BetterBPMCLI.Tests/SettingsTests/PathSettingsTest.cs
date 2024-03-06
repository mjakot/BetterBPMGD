using BetterBPMGDCLI.Models.Settings;

namespace BetterBPMCLI.Tests.SettingsTests
{
    public class PathSettingsTest
    {
        [Fact]
        public void GetDefault_AppDataFolderPath_AppDataFolderPathDefault()
        {
            PathSettings settings = new();

            string expected = settings.AppDataFolderPath; //default constructor sets all fields to default values



            string actual = (string)settings.GetDefault(nameof(settings.AppDataFolderPath));



            Assert.Equal(expected, actual);
        }

        [Fact(Skip = "later")]
        public void ToString_PathSettings_SettingsString()
        {
            PathSettings settings = new();

            string expected =
                $"""
                AppDataFolderPathDefault={Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}
                BetterBPMGDFolderPathDefault={Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\testhost\
                GeometryDashSavesFolderPathDefault={Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\GeometryDash\
                TimingProjectsFolderPathDefault={Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\GeometryDash\
                TimingListPathDefault=Timings.txt
                SongListPathDefault=Songs.txt
                AppDataFolderPath={Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}
                BetterBPMGDFolderPath={Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\testhost\
                GeometryDashSavesFolderPath={Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\GeometryDash\
                TimingProjectsFolderPath={Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\GeometryDash\
                TimingListPath=Timings.txt
                SongListPath=Songs.txt
                
                """;



            string actual = settings.ToString();



            Assert.Equal(expected, actual);
        }

        [Fact]
        public void FromString_SettingsString_PathSettings()
        {
            PathSettings expected = new();

            string settingsString = expected.ToString();



            PathSettings actual = (PathSettings)PathSettings.FromString(settingsString);



            Assert.Equal(expected.AppDataFolderPath, actual.AppDataFolderPath);
            Assert.Equal(expected.BetterBPMGDFolderPath, actual.BetterBPMGDFolderPath);
            Assert.Equal(expected.GeometryDashSavesFolderPath, actual.GeometryDashSavesFolderPath);
            Assert.Equal(expected.TimingProjectsFolderPath, actual.TimingProjectsFolderPath);
            Assert.Equal(expected.TimingListPath, actual.TimingListPath);
            Assert.Equal(expected.SongListPath, actual.SongListPath);
        }
    }
}
