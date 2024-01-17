using BetterBPMGDCLI.Models.Level;
using BetterBPMGDCLI.Utils;

namespace BetterBPMCLI.Tests.LevelTests
{
    public class GuidelinesTest
    {
        [Fact]
        public void Parse_GuidelineString_Guideline()
        {
            const string guidelineString = """0~0.8~"""; // offset = 0, color = orange (0)

            Guideline expected = new(0, GuidelineColors.Orange);



            Guideline? actual = Guideline.Parse(guidelineString);



            Assert.NotNull(actual);
            Assert.Equal(expected.OffsetMs, actual.OffsetMs);
            Assert.Equal(expected.GuidelineColor.GuidelineColor, actual.GuidelineColor.GuidelineColor);
        }

        [Fact]
        public void Encode_Guideline_GuidelineString()
        {
            const string expected = """0~0.8~"""; // offset = 0, color = orange (0)

            Guideline guideline = new(0, GuidelineColors.Orange);



            string actual = guideline.Encode();



            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ParseGuidelines_GuidelinesString_Guidelines()
        {
            const string guidelinesString = """0~0.8~1~0.9~2~1~3~0.1~4~0~"""; /* { offset = 0, color = orange },
                                                                               * { offset = 1, color = yellow },
                                                                               * { offset = 2, color = green },
                                                                               * { offset = 3, color = none },
                                                                               * { offset = 4, color = orange } */

            IReadOnlyList<Guideline> expected = [
                    new(BPMCalculations.GetMilliseconds(0), GuidelineColors.Orange),
                    new(BPMCalculations.GetMilliseconds(1), GuidelineColors.Yellow),
                    new(BPMCalculations.GetMilliseconds(2), GuidelineColors.Green), 
                    new(BPMCalculations.GetMilliseconds(3), GuidelineColors.None),
                    new(BPMCalculations.GetMilliseconds(4), new(0))
                ];



            IEnumerable<Guideline> actual = Guideline.ParseGuidelines(guidelinesString);



            Parallel.For(0, actual.Count(), index =>
            {
                Assert.Equal(expected[index].OffsetMs, actual.ElementAt(index).OffsetMs);
                Assert.Equal(expected[index].GuidelineColor.GuidelineColor, actual.ElementAt(index).GuidelineColor.GuidelineColor);
            });
        }
    }
}
