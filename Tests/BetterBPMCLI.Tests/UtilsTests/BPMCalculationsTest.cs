using BetterBPMGDCLI.Utils;

namespace BetterBPMCLI.Tests.UtilsTest
{
    public class BPMCalculationsTest
    {
        [Fact]
        public void CalculateTimingDuration_ValidInput_ReturnValidDuration()
        {
            const ulong firstTimingOffset = 0;
            const ulong secondTimingOffset = 1;
            const ulong expectedDeration = 1;



            ulong actualDeration = BPMCalculations.CalculateTimingDuration(firstTimingOffset, secondTimingOffset);



            Assert.Equal(expectedDeration, actualDeration);
        }

        [Fact]
        public void CalculateBeatDuration_OneBPM_ReturnsOneMinuteDuration()
        {
            const double bpm = 1;
            const ulong expectedDuration = 60000; // Milliseconds in 1 minute



            ulong actualDuration = BPMCalculations.CalculateBeatDuration(bpm);



            Assert.Equal(expectedDuration, actualDuration);
        }

        [Fact]
        public void CalculateBeatDuration_TwoBPM_ReturnsTwoMinutesDuration()
        {
            const double bpm = 2;
            const ulong expectedDuration = 60000 / 2; // Milliseconds in half a minute



            ulong actualDuration = BPMCalculations.CalculateBeatDuration(bpm);



            Assert.Equal(expectedDuration, actualDuration);
        }
    }
}
