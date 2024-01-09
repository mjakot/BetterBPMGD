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

        public Project(string name, int songId, ulong songOffsetMS = 0)
        {
            Name = name;
            songIds = new() { { songId, songOffsetMS } };
            timings = new();
        }

        public void AddSong(int id, ulong offset) => songIds.Add(id, offset);

        public void AddTiming(Timing timing) => timings.Add(timing);

        public static Project CreateNew(string name, int initialSongId, ulong songOffsetMs = 0)
        {
            return new(name, initialSongId, songOffsetMs);
        }
    }
}
