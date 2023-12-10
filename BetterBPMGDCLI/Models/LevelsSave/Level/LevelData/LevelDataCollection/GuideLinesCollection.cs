using System.Text;

namespace BetterBPMGDCLI.Models.LevelsSave.Level.LevelData.LevelDataCollection
{
    public class GuidelinesCollection : BaseLevelDataCollection
    {
        public override string Encode()
        {
            StringBuilder result = new();

            foreach (Guideline item in collection)
            {
                result.Append(item.Encode());
            }

            result.Append('~');

            return result.ToString();
        }
    }
}
