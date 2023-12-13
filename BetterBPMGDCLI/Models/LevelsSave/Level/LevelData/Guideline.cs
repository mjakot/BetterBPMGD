namespace BetterBPMGDCLI.Models.LevelsSave.Level.LevelData
{
    public class Guideline : ILevelData
    {
        public GuidelineColors GuidelineColor { get; }
        public ulong Offset { get; }

        public Guideline(GuidelineColors guidelineColor, ulong offset)
        {
            GuidelineColor = guidelineColor;
            Offset = offset;
        }

        public string Encode() => $"{Offset}~{GuidelineColor.GuidelineColor}";
    }
}
