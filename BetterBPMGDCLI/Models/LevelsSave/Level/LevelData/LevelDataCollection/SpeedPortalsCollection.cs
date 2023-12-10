using System.Text;

namespace BetterBPMGDCLI.Models.LevelsSave.Level.LevelData.LevelDataCollection
{
    public class SpeedPortalsCollection : BaseLevelDataCollection
    {
        public override string Encode()
        {
            StringBuilder sb = new();

            foreach (SpeedPortal item in collection)
            {
                sb.Append(item.Encode());
                sb.Append(';');
            }

            return sb.ToString();
        }
    }
}
