namespace BetterBPMGDCLI.Utils
{
    public static class BPMCalculations
    {
        public const int MillisecondsInMinute = 60000;

        public static ulong CalculateTimingDuration(ulong firstTimingOffset, ulong secondTimingOffset) => secondTimingOffset - firstTimingOffset;

        public static ulong CalculateBeatDuration(double bpm) => (ulong)(MillisecondsInMinute / bpm);

        public static double GetMinutes(ulong milliseconds) => (double)milliseconds / MillisecondsInMinute;
    }
}
