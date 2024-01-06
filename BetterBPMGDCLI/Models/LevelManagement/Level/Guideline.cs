namespace BetterBPMGDCLI.Models.LevelManagement.Level
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

        public string Encode() => $"{GetMinutes(OffsetMs)}~{GuidelineColor.GuidelineColor}";  // bro why offset for guidelines in gd is in minutes wtf

        private static double GetMinutes(ulong milliseconds) => (double)milliseconds / 1000 / 60;
    }
}
