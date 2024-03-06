using BetterBPMGDCLI.Utils;
using Common;

namespace BetterBPMGDCLI.Models.LevelObjects
{
    public class SpeedPortal : LevelObjectBase
    {
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

        public override string Encode() => base.Encode(new() { { Constants.CheckedKey, Checked ? "1" : "0" } });

        public new static SpeedPortal Parse(string data)
        {
            int objectId = 0;
            double posX = 0;
            double posY = 0;
            bool isChecked = false;

            string[] keyValues = data.Replace(Constants.ObjectEnd, string.Empty).Split(Constants.DataSeparator);

            for(int index = 0; index < keyValues.Length; index+=2)
            {
                switch (keyValues[index])
                {
                    case Constants.ObjectIdKey:
                        objectId = int.Parse(keyValues[index + 1]);
                        break;

                    case Constants.PositionXKey:
                        posX = double.Parse(keyValues[index + 1]);
                        break;

                    case Constants.PositionYKey:
                        posY = double.Parse(keyValues[index + 1]);
                        break;

                    case Constants.CheckedKey:
                        if (int.Parse(keyValues[index + 1]) != 0) 
                            isChecked = true;
                        break;

                    default:
                        break;
                }
            }

            return new(objectId, posX, posY, isChecked);
        }

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
