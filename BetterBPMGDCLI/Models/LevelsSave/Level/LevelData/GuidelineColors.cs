namespace BetterBPMGDCLI.Models.LevelsSave.Level.LevelData
{
    public struct GuidelineColors
    {
        public readonly double GuidelineColor { get; }

        public GuidelineColors None => new(0.0);
        public GuidelineColors Orange => new(0.8);
        public GuidelineColors Yellow => new(0.9);
        public GuidelineColors Green => new(1.0);

        public GuidelineColors(double color) => GuidelineColor = color;
    }
}
