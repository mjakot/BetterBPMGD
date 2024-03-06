using System.Text;
using BetterBPMGDCLI.Extensions;
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

        public string Encode() => new StringBuilder().AppendWithSeparator(BPMCalculations.GetMinutes(OffsetMs), Constants.GuidelinesSeparator)
                                                        .AppendWithSeparator(GuidelineColor.GuidelineColor, Constants.GuidelinesSeparator)
                                                        .ToString(); // bro why offset for guidelines in gd is in minutes wtf
        public static Guideline? Parse(string guideline)
        {
            string[] offsetColorPair = guideline.Split(Constants.GuidelinesSeparator);

            if (offsetColorPair.Length < 2)
                return null;

            return new(BPMCalculations.GetMilliseconds(ulong.Parse(offsetColorPair[0])), new(double.Parse(offsetColorPair[1])));
        }

        public static IEnumerable<Guideline> ParseGuidelines(string guidelines)
        {
            sbyte counter = 0;

            string[] splittedGuidelines = guidelines.Split(Constants.GuidelinesSeparator);

            StringBuilder stringBuilder = new();

            for (int i = 0; i < splittedGuidelines.Length; i++)
            {
                stringBuilder.AppendWithSeparator(splittedGuidelines[i], Constants.GuidelinesSeparator);

                if (counter == 1)
                {
                    counter = 0;

                    yield return Parse(stringBuilder.ToString())!;

                    stringBuilder.Clear();
                }

                else
                    counter++;
            }
        }
    }
}
