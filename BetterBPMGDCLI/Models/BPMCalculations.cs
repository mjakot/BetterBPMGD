namespace BetterBPMGDCLI.Models
{
    public static class BPMCalculations
    {
        private const int MSinSec = 60000;

        public static ulong CalculateTimingDuration(ulong firstTimingOffset, ulong secondTimingOffset) => secondTimingOffset - firstTimingOffset;

        public static ulong CalculateBeatDuration(double bpm) => (ulong)(MSinSec / bpm);
    }
}
