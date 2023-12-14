using BetterBPMGDCLI.Models.LevelsSave.Level.LevelData.LevelDataCollection;
using Common;
using Level = BetterBPMGDCLI.Models.LevelsSave.Level.Level;

namespace BetterBPMCLI.Tests.ModelsLevelsSaveLevelTests
{
    public class LevelTest
    {
        const ulong MillisecondsInMinute = 60000;

        [Fact]
        public void CalculateGuidelines_ValidTiming_ReturnValidGuidelinesCollectionWithCorrectOffset()
        {
            Timing timing = new(0, 1, false, new(1, 1), SpeedPortalTypes.NORMAL, "o");

            Level level = new(timing, MillisecondsInMinute);

            string expected = "0~0.8~"; // Offset~Color, offset 0 seconds and color orange



            GuidelinesCollection returnedGuidelines = level.CalculateGuidelines();

            string actual = returnedGuidelines.Encode();



            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CalculateGuidelines_ValidTimings_ReturnValidGuidelinesCollectionWithCorrectOffsets()
        {
            Timing sampleTiming1 = new(0, 1, false, new(1, 1), SpeedPortalTypes.NORMAL, "o"); // 0~0.8~
            Timing sampleTiming2 = new(MillisecondsInMinute / 2, 2, false, new(1, 1), SpeedPortalTypes.NORMAL, "y"); // 0.5~0.9~
            Timing sampleTiming3 = new(MillisecondsInMinute, 4, false, new(1, 1), SpeedPortalTypes.NORMAL, "g"); // 1~1~1.25~1~1.5~1~1.75~1~

            Timing[] timings = [ sampleTiming1, sampleTiming2, sampleTiming3 ];

            Level level = new(timings, MillisecondsInMinute * 2 /* 2 minutes */);

            string expected = "0~0.8~0.5~0.9~1~1~1.25~1~1.5~1~1.75~1~"; // Offset~Color~Offset~Color 0~0.8~ + 0.5~0.9~ + 1~1~1.25~1~1.5~1~1.75~1~



            GuidelinesCollection returnedGuidelines = level.CalculateGuidelines();

            string actual = returnedGuidelines.Encode();



            Assert.Equal(expected, actual);
        }
    }
}
