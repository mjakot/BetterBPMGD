using Common;

namespace BetterBPMGDCLI.Models.LevelsSave.Level
{
    public struct SpeedPortal
    {
        public SpeedPortalTypes PortalType { get; }
        public double PositionX { get; }
        public double PositionY { get; }
        public bool Checked { get; }

        public SpeedPortal(SpeedPortalTypes portalType, double posX, double posY, bool isChecked)
        {
            PortalType = portalType;
            PositionX = posX;
            PositionY = posY;
            Checked = isChecked;
        }

        public string Encode()
        {
            int actualPortalType = PortalType switch
            {
                SpeedPortalTypes.HALFSPEED => 200,
                SpeedPortalTypes.NORMAL => 201,
                SpeedPortalTypes.DOUBLE => 202,
                SpeedPortalTypes.TRIPLE => 203,
                SpeedPortalTypes.QUADRUPLE => 1334,
                _ => 0
            };

            return $"1,{actualPortalType},2,{PositionX},3{PositionY},13{Checked}";
        }
    }
}
