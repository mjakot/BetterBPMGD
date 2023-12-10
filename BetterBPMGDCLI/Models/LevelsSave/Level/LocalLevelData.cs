using BetterBPMGDCLI.Models.LevelsSave.Level.LevelData.LevelDataCollection;

namespace BetterBPMGDCLI.Models.LevelsSave.Level
{
    public class LocalLevelData : Common.Level
    {
        public ILevelDataCollection GuideLines { get; }
        public ILevelDataCollection SpeedPortals { get; }
    }
}
