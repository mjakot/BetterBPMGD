using BetterBPMGDCLI.Extensions;
using System.Xml.Linq;

namespace BetterBPMGDCLI.Models.LevelsSave.Level
{
    public class LocalLevel
    {
        private readonly int id;
        private LocalLevelData levelData;

        public int Id => id;
        public LocalLevelData LevelData => levelData;

        public LocalLevel(int id, LocalLevelData? levelData)
        {
            this.id = id;
            this.levelData = levelData ?? new(string.Empty);
        }

        public LocalLevel(int id, XElement levelElement)
        {
            LocalLevel instance = levelElement.ToXDocument().ToLocalLevel(id);

            this.id = instance.Id;
            levelData = instance.LevelData;
        }
    }
}
