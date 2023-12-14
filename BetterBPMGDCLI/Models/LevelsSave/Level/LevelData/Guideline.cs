namespace BetterBPMGDCLI.Models.LevelsSave.Level.LevelData
{
    public class Guideline : ILevelData
    {
        public GuidelineColors GuidelineColor { get; }
        public ulong OffsetMs { get; }

        public Guideline(GuidelineColors guidelineColor, ulong offset)
        {
            GuidelineColor = guidelineColor;
            OffsetMs = offset;
        }

        public string Encode() => $"{(double)OffsetMs / 1000 / 60}~{GuidelineColor.GuidelineColor}";
    }
}
