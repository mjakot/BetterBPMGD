using Common;
using System.Linq.Expressions;

namespace BetterBPMGDCLI.Models.LevelManagement.Level
{
    public class SpeedPortal : LevelObjectBase
    {
        public const string CheckedKey = "13";

        public SpeedPortalTypes PortalType { get; }
        public bool Checked { get; }

        public SpeedPortal(SpeedPortalTypes portalType, double posX, double posY, bool isChecked = true) : base(DeductObjectId(portalType), posX, posY)
        {
            PortalType = portalType;
            Checked = isChecked;
        }

        public SpeedPortal(int objectId, double posX, double posY, bool isChecked = true) : base(objectId, posX, posY)
        {
            PortalType = DeductSpeedPortalType(objectId);
            Checked = isChecked;
        }

        public override string Encode() => base.Encode(new() { { CheckedKey, Checked.ToString() } });

        private static int DeductObjectId(SpeedPortalTypes portalType) => portalType switch
        {
            SpeedPortalTypes.HALFSPEED => 200,
            SpeedPortalTypes.NORMAL => 201,
            SpeedPortalTypes.DOUBLE => 202,
            SpeedPortalTypes.TRIPLE => 203,
            SpeedPortalTypes.QUADRUPLE => 1334,
            _ => 0
        };

        private static SpeedPortalTypes DeductSpeedPortalType(int objectId) => objectId switch
        {
            200 => SpeedPortalTypes.HALFSPEED,
            201 => SpeedPortalTypes.NORMAL,
            202 => SpeedPortalTypes.DOUBLE,
            203 => SpeedPortalTypes.TRIPLE,
            1334 => SpeedPortalTypes.QUADRUPLE,
            _ => SpeedPortalTypes.HALFSPEED
        };
    }
}
