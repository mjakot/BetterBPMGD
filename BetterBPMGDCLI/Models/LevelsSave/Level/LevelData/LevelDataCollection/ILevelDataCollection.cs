using System.Collections;

namespace BetterBPMGDCLI.Models.LevelsSave.Level.LevelData.LevelDataCollection
{
    public interface ILevelDataCollection : ICollection
    {
        public IEnumerable<ILevelData> Collection { get; }

        public string Encode();
    }
}
