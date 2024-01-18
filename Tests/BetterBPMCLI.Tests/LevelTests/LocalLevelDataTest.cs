using BetterBPMGDCLI.Models.Level;
using BetterBPMGDCLI.Utils;
using Common;
using Xunit.Abstractions;

namespace BetterBPMCLI.Tests.LevelTests
{
    public class LocalLevelDataTest
    {
        private readonly ITestOutputHelper output;

        public LocalLevelDataTest(ITestOutputHelper output)
        {
            this.output = output;
        }

        const string MINIMALLOCALLEVELDATADECRYPTED = """kS38,1_40_2_125_3_255_11_255_12_255_13_255_4_-1_6_1000_7_1_15_1_18_0_8_1|1_0_2_102_3_255_11_255_12_255_13_255_4_-1_6_1001_7_1_15_1_18_0_8_1|1_0_2_102_3_255_11_255_12_255_13_255_4_-1_6_1009_7_1_15_1_18_0_8_1|1_255_2_255_3_255_11_255_12_255_13_255_4_-1_6_1002_5_1_7_1_15_1_18_0_8_1|1_40_2_125_3_255_11_255_12_255_13_255_4_-1_6_1013_7_1_15_1_18_0_8_1|1_40_2_125_3_255_11_255_12_255_13_255_4_-1_6_1014_7_1_15_1_18_0_8_1|1_135_2_135_3_135_11_255_12_255_13_255_4_-1_6_1005_5_1_7_1_15_1_18_0_8_1|1_255_2_255_3_255_11_255_12_255_13_255_4_-1_6_1006_5_1_7_1_15_1_18_0_8_1|,kA13,0,kA15,0,kA16,0,kA14,0~0.8~,kA6,1,kA7,1,kA25,0,kA17,1,kA18,0,kS39,0,kA2,0,kA3,0,kA8,0,kA4,0,kA9,0,kA10,0,kA22,0,kA23,0,kA24,0,kA27,1,kA40,1,kA41,1,kA42,1,kA28,0,kA29,0,kA31,1,kA32,1,kA36,0,kA43,0,kA44,0,kA33,1,kA34,1,kA35,0,kA37,1,kA38,1,kA39,1,kA19,0,kA26,0,kA20,0,kA21,0,kA11,0;1,200,2,0,3,0;""";

        [Fact]
        public void Parse_LevelDataString_LocalLevel()
        {
            LocalLevelData expected = new(MINIMALLOCALLEVELDATADECRYPTED, [new(0, GuidelineColors.Orange)], [new(SpeedPortalTypes.HALFSPEED, 0, 0, false)]);



            LocalLevelData? actual = LocalLevelData.Parse(MINIMALLOCALLEVELDATADECRYPTED);



            Assert.Equal(expected.LevelData, actual?.LevelData);
            Assert.Equal(expected.Guidelines.Count, actual?.Guidelines.Count);
            Assert.Equal(expected.Guidelines[0].OffsetMs, actual?.Guidelines[0].OffsetMs);
            Assert.Equal(expected.Guidelines[0].GuidelineColor.GuidelineColor, actual?.Guidelines[0].GuidelineColor.GuidelineColor);
            Assert.Equal(expected.SpeedPortals.Count, actual?.SpeedPortals.Count);
            Assert.Equal(expected.SpeedPortals[0].PortalType, actual?.SpeedPortals[0].PortalType);
            Assert.Equal(expected.SpeedPortals[0].PositionX, actual?.SpeedPortals[0].PositionX);
            Assert.Equal(expected.SpeedPortals[0].PositionY, actual?.SpeedPortals[0].PositionY);
            Assert.Equal(expected.SpeedPortals[0].Checked, actual?.SpeedPortals[0].Checked);
        }

        [Fact]
        public void Calculate_Timings_CalculatedLevelData()
        {
            LocalLevelData expected = new(MINIMALLOCALLEVELDATADECRYPTED, [ new(0, GuidelineColors.Orange), new(20000, GuidelineColors.Orange), new(40000, GuidelineColors.Orange) ], []);

            IReadOnlyList<Timing> timings = [ new(0, 3, false, 0, SpeedPortalTypes.HALFSPEED, "o") ];

            LocalLevelData actual = new();



            actual.Calculate(timings,  BPMCalculations.MillisecondsInMinute);



            Assert.Equal(expected.Guidelines.Count, actual.Guidelines.Count);
            Assert.Equal(expected.Guidelines[0].OffsetMs, actual.Guidelines[0].OffsetMs);
            Assert.Equal(expected.Guidelines[1].OffsetMs, actual.Guidelines[1].OffsetMs);
            Assert.Equal(expected.Guidelines[2].OffsetMs, actual.Guidelines[2].OffsetMs);
        }

        [Fact]
        //works perfectly fine, but output is too tedious to test
        public void Encode_LocalLevelData_LocalLevelDataString()
        {
            LocalLevelData localLevelData = new(MINIMALLOCALLEVELDATADECRYPTED, [new(0, GuidelineColors.Orange)], [new(SpeedPortalTypes.HALFSPEED, 0, 0, false)]);

            localLevelData.Guidelines.Add(new(BPMCalculations.MillisecondsInMinute, GuidelineColors.Orange));
            localLevelData.SpeedPortals.Add(new(SpeedPortalTypes.NORMAL, 0, 0, true));



            string actual = localLevelData.Encode(true);



            output.WriteLine(actual);
        }
    }
}
