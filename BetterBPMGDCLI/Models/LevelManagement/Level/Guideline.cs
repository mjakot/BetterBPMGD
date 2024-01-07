using System.Text;
using BetterBPMGDCLI.Utils;

namespace BetterBPMGDCLI.Models.Level
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
            sbyte counter = 0;

            string[] splittedGuidelines = guidelines.Split('~');

            StringBuilder stringBuilder = new();

            for (int i = 0; i < splittedGuidelines.Length; i++)
            {
                stringBuilder.Append(splittedGuidelines[i]);
                stringBuilder.Append('~');

                if (counter == 1)
                {
                    counter = 0;

                    yield return Parse(stringBuilder.ToString())!;
                }

                else counter++;
            }
        }
    }
}
