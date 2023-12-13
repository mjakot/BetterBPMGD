using System.Text;

namespace BetterBPMGDCLI.Models.LevelsSave.Level.LevelData.LevelDataCollection
{
    public class SpeedPortalsCollection : BaseLevelDataCollection
    {
        public SpeedPortalsCollection() : base() { }

        public SpeedPortalsCollection(IEnumerable<SpeedPortal> collection) : base(collection) { }

        public SpeedPortalsCollection(List<SpeedPortal> collection) : base(collection) { }

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
