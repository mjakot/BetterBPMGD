using Common;

namespace BetterBPMGDCLI.Extensions
{
    public static class TimingExtension
    {
        public static string ToString(this Timing timing) => timing.Serialize();

        public static Timing FromString(string timing) => timing.Desirialize<Timing>();
    }
}
