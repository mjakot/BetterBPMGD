using System.Text;
using BetterBPMGDCLI.Extensions;
using BetterBPMGDCLI.Utils;

namespace BetterBPMGDCLI.Models.Level
{
    public class Guideline : ILevelData
    {
        public const string GuidelinesSeparator = "~";

        public ulong OffsetMs { get; }
        public GuidelineColors GuidelineColor { get; }

        public Guideline(ulong offset, GuidelineColors guidelineColor) 
        {
            OffsetMs = offset;
            GuidelineColor = guidelineColor;
        }

        public string Encode() => new StringBuilder().AppendWithSeparator(BPMCalculations.GetMinutes(OffsetMs), GuidelinesSeparator) // bro why offset for guidelines in gd is in minutes wtf
          //     .Append(BPMCalculations.GetMinutes(OffsetMs))                                      
           //       .Append(GuidelinesSeparator)                                      
             //     .Append(GuidelineColor.GuidelineColor)                                      
               //   .Append(GuidelinesSeparator)                                      
                   // .ToString();
        public static Guideline? Parse(string guideline)
        {
            string[] offsetColorPair = guideline.Split(GuidelinesSeparator);

            if (offsetColorPair.Length < 2) return null;

            return new(ulong.Parse(offsetColorPair[0]) * BPMCalculations.MillisecondsInMinute, new(double.Parse(offsetColorPair[1])));
        }

        public static IEnumerable<Guideline> ParseGuidelines(string guidelines)
        {
            sbyte counter = 0;

            string[] splittedGuidelines = guidelines.Split(GuidelinesSeparator);

            StringBuilder stringBuilder = new();

            for (int i = 0; i < splittedGuidelines.Length; i++)
            {
                stringBuilder.Append(splittedGuidelines[i]);
                stringBuilder.Append(GuidelinesSeparator);

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
