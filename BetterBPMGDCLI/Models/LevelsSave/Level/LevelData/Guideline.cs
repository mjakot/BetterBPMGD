namespace BetterBPMGDCLI.Models.LevelsSave.Level.LevelData
{
    public struct Guideline : ILevelData
    {
        public GuidelineColors GuidelineColor { get; }
        public double Offset { get; }

        public Guideline(GuidelineColors guidelineColor, double offset)
        {
            GuidelineColor = guidelineColor;
            Offset = offset;
        }

        public string Encode() => $"{Offset}~{GuidelineColor.GuidelineColor}";
    }
}
