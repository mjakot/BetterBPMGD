namespace BetterBPMGDCLI.Utils
{
    public static class BPMCalculations
    {
        public const int MillisecondsInMinute = 60000;
        public const int DecimalPlaces = 5;

        public static ulong CalculateTimingDuration(ulong firstTimingOffset, ulong secondTimingOffset) => secondTimingOffset - firstTimingOffset;

        public static ulong CalculateBeatDuration(double bpm) => (ulong)(MillisecondsInMinute / bpm);

        public static double GetMinutes(ulong milliseconds) => Math.Round((double)milliseconds / MillisecondsInMinute, DecimalPlaces);

        public static ulong GetMilliseconds(double minutes) => (ulong)minutes * MillisecondsInMinute;

        public static ulong GetMilliseconds(ulong minutes) => minutes * MillisecondsInMinute;
    }
}
