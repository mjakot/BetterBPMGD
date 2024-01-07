namespace BetterBPMGDCLI.Models.LevelManagement.Level
{
    public class Guideline : ILevelData
    {
        public ulong OffsetMs { get; }
        public GuidelineColors GuidelineColor { get; }

        public Guideline(ulong offset, GuidelineColors guidelineColor)
        {
            OffsetMs = offset;
            GuidelineColor = guidelineColor;
        }

        public string Encode() => $"{BPMCalculations.GetMinutes(OffsetMs)}~{GuidelineColor.GuidelineColor}~";  // bro why offset for guidelines in gd is in minutes wtf

        public static Guideline? Parse(string guideline)
        {
            string[] offsetColorPair = guideline.Split('~');

            if (offsetColorPair.Length < 2) return null;

            return new(ulong.Parse(offsetColorPair[0]) * BPMCalculations.MillisecondsInMinute, new(double.Parse(offsetColorPair[1])));
        }

        public static IEnumerable<Guideline> ParseGuidelines(string guidelines)
        {
            throw new NotImplementedException();
        }
    }
}
