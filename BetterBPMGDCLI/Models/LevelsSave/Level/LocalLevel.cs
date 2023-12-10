namespace BetterBPMGDCLI.Models.LevelsSave.Level
{
    public class LocalLevel
    {
        private readonly int id;
        private readonly string? name;
        private string? description;
        private LocalLevelData levelData;
        private readonly string? author;
        private bool? verified;

        public int Id => id;
        public string? Name => name;
        public string? Description { get => description; set => description = value; }
        public LocalLevelData LevelData => levelData;
        public string? Author => author;
        public bool? Verified { get => verified; set => verified = value; }

        public LocalLevel(int id, string? name, string? description, LocalLevelData? levelData, string? author, bool? verified)
        {
            this.id = id;
            this.name = name;
            this.description = description;
            this.levelData = levelData ?? new(string.Empty);
            this.author = author;
            this.verified = verified;
        }
    }
}
