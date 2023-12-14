using BetterBPMGDCLI.Models;

namespace BetterBPMCLI.Tests.ModelsTests
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
            const ulong timingDurationMs = 60000; // Milliseconds in 1 minute
            const double bpm = 1;
            const ulong expectedDuration = timingDurationMs;



            ulong actualDuration = BPMCalculations.CalculateBeatDuration(timingDurationMs, bpm);



            Assert.Equal(expectedDuration, actualDuration);
        }

        [Fact]
        public void CalculateBeatDuration_TwoBPM_ReturnsTwoMinutesDuration()
        {
            const ulong timingDurationMs = 60000; // Milliseconds in 1 minute
            const double bpm = 2;
            const ulong expectedDuration = 30000; // Milliseconds in half a minute



            ulong actualDuration = BPMCalculations.CalculateBeatDuration(timingDurationMs, bpm);



            Assert.Equal(expectedDuration, actualDuration);
        }
    }
}
