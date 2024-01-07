namespace BetterBPMGDCLI.Models.Level
{
    public struct GuidelineColors
    {
        public readonly double GuidelineColor { get; }

        public static GuidelineColors None => new(0.1);
        public static GuidelineColors Orange => new(0.8);
        public static GuidelineColors Yellow => new(0.9);
        public static GuidelineColors Green => new(1.0);

        public GuidelineColors(double color) => GuidelineColor = color;

        public static GuidelineColors GetGuidelineColor(char color) => color switch
        {
            'o' or 'O' => Orange,
            'y' or 'Y' => Yellow,
            'g' or 'G' => Green,
            _ => None
        };
    }
}
