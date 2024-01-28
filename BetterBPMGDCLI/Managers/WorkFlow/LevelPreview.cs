using BetterBPMGDCLI.Managers.WorkFlow;

namespace BetterBPMGDCLI.Managers
{
    public struct LevelPreview(string levelKey, string levelName, string levelDescription, int objectCount, LevelLength length)
    {
        public string LevelKey { get; set; } = levelKey;
        public string LevelName { get; set; } = levelName;
        public string LevelDescription { get; set; } = levelDescription;
        public int ObjectCount { get; set; } = objectCount;
        public LevelLength Length { get; set; } = length;
    }
}
