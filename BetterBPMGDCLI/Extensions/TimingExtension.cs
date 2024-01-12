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

        public static string ToString(this Timing timing)
        {
            StringBuilder stringBuilder = new();

            stringBuilder.AddKeyValuePair(OffsetKey, timing.OffsetMS, InnerSeparator);
            stringBuilder.Append(OuterSeparator);
            stringBuilder.AddKeyValuePair(BPMKey, timing.Bpm, InnerSeparator);
            stringBuilder.Append(OuterSeparator);
            stringBuilder.AddKeyValuePair(SubdivideBeatsKey, timing.SubdivideBeats, InnerSeparator);
            stringBuilder.Append(OuterSeparator);
            stringBuilder.AddKeyValuePair(BeatsSubdivisionKey, timing.BeatSubdivision, InnerSeparator);
            stringBuilder.Append(OuterSeparator);
            stringBuilder.AddKeyValuePair(SpeedKey, timing.Speed, InnerSeparator);
            stringBuilder.Append(OuterSeparator);
            stringBuilder.AddKeyValuePair(ColorPatternKey, timing.ColorPattern, InnerSeparator);

            return stringBuilder.ToString();
        }

        public static Timing FromString(string timing)
        {
            Timing result = new();

            IReadOnlyList<string> keyValuePairs = timing.Split(OuterSeparator);

            if (keyValuePairs.Count < 1) return result;

            Parallel.ForEach(keyValuePairs, pair =>
            {
                if (pair == string.Empty) return;

                IReadOnlyList<string> values = pair.Split(InnerSeparator);

                if (values.Count < 1) return;

                switch (values[0])
                {
                    case OffsetKey:
                        result.OffsetMS = ulong.Parse(values[1]);
                        break;

                    case BPMKey:
                        result.Bpm = double.Parse(values[1]);
                        break;

                    case SubdivideBeatsKey:
                        result.SubdivideBeats = bool.Parse(values[1]);
                        break;

                    case BeatsSubdivisionKey:
                        result.BeatSubdivision = int.Parse(values[1]);
                        break;

                    case SpeedKey:
                        SpeedPortalTypes portalType;

                        Enum.TryParse(values[1], true,  out portalType);

                        result.Speed = portalType;
                        break;

                    case ColorPatternKey:
                        result.ColorPattern = values[1];
                        break;

                    default:
                        return;
                }
            });

            return result;
        }
    }
}
