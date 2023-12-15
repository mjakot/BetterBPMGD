using BetterBPMGDCLI.Models;
using BetterBPMGDCLI.Models.LevelsSave.Level;
using BetterBPMGDCLI.Models.Settings;

namespace BetterBPMCLI.Tests.ModelsTests
{
    public class ControllerTest
    {
        [Fact]
        public async Task LoadLocalLevel_ValidXML_ReturnsValidLocalLevel()
        {
            Controller controller = new(new TestSettings());



            await controller.LoadLocalLevelAsync("k_0");

            LocalLevel? localLevel = controller.Level;

            string? actual = localLevel?.LevelData.LevelData;



            Assert.Equal("", actual);
        }

        private class TestSettings : ISettings
        {
            public string DefaultLevelsSavePath => @"C:\SenaFolder\locallevels.xml";

            public string LevelsSavePath { get => DefaultLevelsSavePath; set => throw new NotImplementedException(); }

            public string DefaultCachePath => @"C:\SenaFolder\cachetest.xml";

            public string CachePath { get => DefaultCachePath; set => throw new NotImplementedException(); }

            public void ResetAllSettings()
            {
                throw new NotImplementedException();
            }
        }
    }
}
