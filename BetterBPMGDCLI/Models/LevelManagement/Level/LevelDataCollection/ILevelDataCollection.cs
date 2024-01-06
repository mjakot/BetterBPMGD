using System.Collections;
using BetterBPMGDCLI.Models.LevelManagement.Level;

namespace BetterBPMGDCLI.Models.LevelManagement.Level.LevelDataCollection
{
    public interface ILevelDataCollection : ICollection
    {
        public IEnumerable<ILevelData> Collection { get; }

        public string Encode();
    }
}
