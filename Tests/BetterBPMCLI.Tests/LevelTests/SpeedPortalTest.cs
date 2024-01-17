using BetterBPMGDCLI.Models.LevelObjects;
using Common;

namespace BetterBPMCLI.Tests.LevelTests
{
    public class SpeedPortalTest
    {
        [Fact]
        public void Parse_SpeedPortalString_SpeedPortal()
        {
            const string speedPortalString = """1,200,2,0,3,0;"""; // type = HALFSPEED, x = 0, x = 0, checked = false

            SpeedPortal expected = new(SpeedPortalTypes.HALFSPEED, 0, 0, false);



            SpeedPortal actual = SpeedPortal.Parse(speedPortalString);



            Assert.Equal(expected.PortalType, actual.PortalType);
            Assert.Equal(expected.PositionX, actual.PositionX);
            Assert.Equal(expected.PositionY, actual.PositionY);
            Assert.Equal(expected.Checked, actual.Checked);
            Assert.False(actual.Checked);
        }

        [Fact]
        public void Parse_SpeedPortalStringChecked_SpeedPortalChecked()
        {
            const string speedPortalString = """1,200,2,0,3,0,13,1;"""; // type = HALFSPEED, x = 0, x = 0, checked = true

            SpeedPortal expected = new(SpeedPortalTypes.HALFSPEED, 0, 0);



            SpeedPortal actual = SpeedPortal.Parse(speedPortalString);



            Assert.Equal(expected.PortalType, actual.PortalType);
            Assert.Equal(expected.PositionX, actual.PositionX);
            Assert.Equal(expected.PositionY, actual.PositionY);
            Assert.Equal(expected.Checked, actual.Checked);
            Assert.True(actual.Checked);
        }

        [Fact]
        public void Encode_SpeedPortal_SpeedPortalString()
        {
            SpeedPortal speedPortal = new(SpeedPortalTypes.HALFSPEED, 0, 0);

            const string expected = """1,200,2,0,3,0,13,1;"""; // type = HALFSPEED, x = 0, x = 0, checked = true



            string actual = speedPortal.Encode();



            Assert.Equal(expected, actual);
        }
    }
}
