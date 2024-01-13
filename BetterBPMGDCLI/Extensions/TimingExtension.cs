using Common;
using System.Text;

namespace BetterBPMGDCLI.Extensions
{
    public static class TimingExtension
    {
        public const string InnerSeparator = "=";
        public const string OuterSeparator = ",";
        
        public const string OffsetKey = "offset";
        public const string BPMKey = "bpm";
        public const string SubdivideBeatsKey = "doSubdivide";
        public const string BeatsSubdivisionKey = "subdivision";
        public const string SpeedKey = "speed";
        public const string ColorPatternKey = "colorPattern";

        public static string ToString(this Timing timing) => timing.Serialize();

        public static Timing FromString(string timing) => timing.Desirialize<Timing>();
    }
}
