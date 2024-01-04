using Common;

namespace BetterBPMGDCLI.Extensions
{
    public static class TimingExtension
    {
        public static IEnumerable<Timing> Sort(IEnumerable<Timing> timings) => timings.OrderBy(timings => timings.OffsetMS);

        public static string Serialize(this Timing timing) => $"offset={timing.OffsetMS},bpm={timing.Bpm},subdivide={timing.SubdivideBeats},subdivision={timing.BeatSubdivision},speed={timing.Speed},pattern={timing.ColorPattern}{Environment.NewLine}";

        public static Timing Deserialize(string timing)
        {
            Timing result = new();

            string[] properties = timing.Replace(Environment.NewLine, string.Empty).Split(',');

            foreach (string property in properties)
            {
                string[] keyValue = property.Split('=');

                switch (keyValue[0])
                {
                    case "offset":
                        result.OffsetMS = ulong.Parse(keyValue[1]);
                        break;

                    case "bpm":
                        result.Bpm = double.Parse(keyValue[1]);
                        break;

                    case "subdivide":
                        result.SubdivideBeats = bool.Parse(keyValue[1]);
                        break;

                    case "subdivision":
                        result.BeatSubdivision = int.Parse(keyValue[1]);
                        break;

                    case "speed":
                        SpeedPortalTypes portal;

                        Enum.TryParse(keyValue[1], out portal);

                        result.Speed = portal;
                        break;

                    case "pattern":
                        result.ColorPattern = keyValue[1];
                        break;

                    default:
                        break;
                }
            }

            return result;
        }
    }
}
