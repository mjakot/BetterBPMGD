using System.Text;

namespace BetterBPMGDCLI.Managers
{
    public struct LevelPreview(string levelKey, string levelName, string levelDescription, int objectCount, LevelLength length)
    {
        public string LevelKey { get; set; } = levelKey;
        public string LevelName { get; set; } = levelName;
        public string LevelDescription { get; set; } = levelDescription;
        public int ObjectCount { get; set; } = objectCount;
        public LevelLength Length { get; set; } = length;

        public override string ToString() => new StringBuilder().AppendLine($"Key - {LevelKey}")
                                                                .AppendLine($"Name - {LevelName}")
                                                                .AppendLine($"Description - {LevelDescription}")
                                                                .AppendLine($"Object count - {ObjectCount}")
                                                                .AppendLine($"Length - {Length}")
                                                                .ToString();
    }
}
