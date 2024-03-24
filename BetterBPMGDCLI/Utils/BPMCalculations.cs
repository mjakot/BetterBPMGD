namespace BetterBPMGDCLI.Utils
{
    public static class BPMCalculations
    {
        public static ulong CalculateTimingDuration(ulong firstTimingOffset, ulong secondTimingOffset) => secondTimingOffset - firstTimingOffset;

        public static ulong CalculateBeatDuration(double bpm) => (ulong)(Constants.MillisecondsInMinute / bpm);

        public static double GetMinutes(ulong milliseconds) => Math.Round((double)milliseconds / Constants.MillisecondsInMinute, Constants.RoundToDecimalPlaces);

        public static double GetSeconds(ulong milliseconds) => Math.Round((double)milliseconds / Constants.MillisecondsInSecond, Constants.RoundToDecimalPlaces);

        public static ulong GetMilliseconds(double minutes) => (ulong)minutes * Constants.MillisecondsInMinute;

        public static ulong GetMilliseconds(ulong minutes) => minutes * Constants.MillisecondsInMinute;
    }
}
