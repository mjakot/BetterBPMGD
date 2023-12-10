using System.Collections;

namespace BetterBPMGDCLI.Models.LevelsSave.Level.LevelData.LevelDataCollection
{
    public interface ILevelDataCollection : ICollection
    {
        public List<ILevelData> List { get; }

        public string Encode();
    }
}
