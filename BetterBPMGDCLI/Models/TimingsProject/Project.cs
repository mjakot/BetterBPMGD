using Common;

namespace BetterBPMGDCLI.Models.TimingsProject
{
    public class Project
    {
        private Dictionary<int, ulong> songIds;
        private List<Timing> timings;

        public string Name { get; set; }
        public IEnumerable<KeyValuePair<int, ulong>> SongIds => songIds;
        public IEnumerable<Timing> Timings => timings;

        public Project(string name, int songId, ulong offsetMS = 0)
        {
            Name = name;
            songIds = new() { { songId, offsetMS } };
            timings = new();
        }
    }
}
