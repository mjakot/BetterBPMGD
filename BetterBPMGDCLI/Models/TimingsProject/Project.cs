using BetterBPMGDCLI.Models.Level;
using BetterBPMGDCLI.Models.Settings;
using BetterBPMGDCLI.Utils;
using Common;
using NAudio.Wave;
using System.Xml.Linq;

namespace BetterBPMGDCLI.Models.TimingsProject
{
    public class Project
    {
        private IPathSettings pathSettings;

        private Dictionary<int, ulong> songIds;
        private List<Timing> timings;

        public string Name { get; set; }
        public IEnumerable<KeyValuePair<int, ulong>> SongIds => songIds;
        public IEnumerable<Timing> Timings => timings;

        public Project(IPathSettings settings, string name, int songId, ulong songOffsetMS = 0)
        {
            InitializeProject(settings, name, songId);

            pathSettings = settings;
            Name = name;
            songIds = new() { { songId, songOffsetMS } };
            timings = new();
        }

        public void AddSong(int id, ulong offset) => songIds.Add(id, offset);

        public void AddTiming(Timing timing) => timings.Add(timing);

        public void InjectTimings(LocalLevel level)
        {
            KeyValuePair<int, ulong> lastSong = songIds.OrderBy(pair => pair.Value).LastOrDefault();

            using Mp3FileReader reader = new(Path.Combine(pathSettings.GetTimingProjectFolderPath(Name), $"{lastSong.Key}.mp3"));

            ulong duration = (ulong)reader.TotalTime.TotalMicroseconds;

            level.LevelData?.Calculate(timings, duration + lastSong.Value);
        }

        private static void InitializeProject(IPathSettings settings, string projectName, int initialSongId)
        {
            string projectPath = settings.GetTimingProjectFolderPath(projectName);
            string initialSongPath = settings.GetSongPathById(initialSongId);

            FileUtility.CreateNewFolder(projectPath);
            FileUtility.CopyFile(initialSongPath, Path.Combine(projectPath, Path.GetFileName(initialSongPath)));
            FileUtility.WriteToFile(Path.Combine(projectPath, settings.TimingsListPath), string.Empty);
        }
    }
}
