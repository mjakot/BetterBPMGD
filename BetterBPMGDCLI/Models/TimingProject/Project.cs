using BetterBPMGDCLI.Extensions;
using BetterBPMGDCLI.Managers;
using BetterBPMGDCLI.Models.Level;
using BetterBPMGDCLI.Models.Settings;
using BetterBPMGDCLI.Utils;
using Common;
using NAudio.Wave;
using System.Text;

namespace BetterBPMGDCLI.Models.TimingProject
{
    public class Project : IDisposable
    {
        private ConfigManager configManager;
        private IPathSettings pathSettings;

        private Dictionary<int, ulong> songIds;
        private List<Timing> timings;

        public string Name { get; set; }
        public IReadOnlyDictionary<int, ulong> SongIds => songIds;
        public IReadOnlyList<Timing> Timings => timings;

        public Project(ConfigManager configManager) : this(configManager, string.Empty, default) { }
        public Project(ConfigManager configManager, string name, int songId, ulong songOffsetMS = 0)
        {
            this.configManager = configManager;
            pathSettings = configManager.PathSettings;
            Name = name;
            songIds = new() { { songId, songOffsetMS } };
            timings = [];

            configManager.PropertyChanged += ConfigManager_PropertyChanged;
        }

        public void Dispose()
        {
            return;
        }

        public void AddSong(int id, ulong offset) => songIds.Add(id, offset);
        public void AddSongs(IReadOnlyDictionary<int, ulong> songs)
        {
            foreach (KeyValuePair<int, ulong> song in songs)
                songIds.Add(song.Key, song.Value);
        }

        public void AddTiming(Timing timing) => timings.Add(timing);
        public void AddTimings(IEnumerable<Timing> timings) => this.timings.AddRange(timings);

        public void ClearSongs() => songIds.Clear();

        public void ClearTimings() => timings.Clear();

        public static Project CreateNew(ConfigManager config, string projectName, int initialSongId, ulong songOffsetMS = 0)
        {
            InitializeProject(config, projectName, initialSongId);

            return new(config, projectName, initialSongId, songOffsetMS);
        }

        public static Project ReadProject(ConfigManager config, string projectName) => ReadProject(config, config.PathSettings.GetTimingProjectFolderPath(projectName), config.PathSettings.SongListPath, config.PathSettings.TimingListPath);

        public static Project ReadProject(ConfigManager config, string projectFolderPath, string songsListFileName, string timingsListFileName)
        {
            if (!Path.HasExtension(songsListFileName)) songsListFileName += Path.ChangeExtension(songsListFileName, Constants.MP3Extension);
            if (!Path.HasExtension(timingsListFileName)) timingsListFileName += Path.ChangeExtension(timingsListFileName, Constants.MP3Extension);

            string songsListPath = Path.Combine(projectFolderPath, songsListFileName);
            string timingsListPath = Path.Combine(projectFolderPath, timingsListFileName);

            string name = Path.GetFileName(Path.GetDirectoryName(projectFolderPath) ?? string.Empty);
            string songs = FileUtility.ReadFromFile(songsListPath);
            string timings = FileUtility.ReadFromFile(timingsListPath);

            Project result = new(config) { Name = name };

            result.AddSongs(DesirializeSongs(songs));
            result.AddTimings(DesirializeTimings(timings));

            return result;
        }

        public void SaveProject()
        {
            string serializedTimings = SerializeTimings(timings);
            string serializedSongs = SerializeSongs(songIds);

            FileUtility.WriteToFile(pathSettings.GetTimingListPath(Name), serializedTimings);
            FileUtility.WriteToFile(pathSettings.GetSongListPath(Name), serializedSongs);
        }

        public void InjectTimings(LocalLevel level)
        {
            KeyValuePair<int, ulong> lastSong = songIds.OrderBy(pair => pair.Value).LastOrDefault();

            using Mp3FileReader reader = new(Path.Combine(pathSettings.GetTimingProjectFolderPath(Name), Path.ChangeExtension(lastSong.Key.ToString(), Constants.MP3Extension)));

            ulong duration = (ulong)reader.TotalTime.TotalMilliseconds;

            level.LevelData?.Calculate(timings, duration + lastSong.Value);
        }

        private static void InitializeProject(ConfigManager config, string projectName, int initialSongId)
        {
            string projectPath = config.PathSettings.GetTimingProjectFolderPath(projectName);
            string initialSongPath = Path.Combine(config.PathSettings.GeometryDashSavesFolderPath, Path.ChangeExtension(initialSongId.ToString(), Constants.MP3Extension));

            FileUtility.CreateNewFolder(projectPath);
            FileUtility.CopyFile(initialSongPath, Path.Combine(projectPath, Path.GetFileName(initialSongPath)));
            FileUtility.WriteToFile(config.PathSettings.GetTimingListPath(projectName), string.Empty);
            FileUtility.WriteToFile(config.PathSettings.GetSongListPath(projectName), string.Empty);
        }

        private static string SerializeTimings(IReadOnlyList<Timing> timings)
        {
            StringBuilder stringBuilder = new();

            Parallel.ForEach(timings, timing => stringBuilder.AppendLine(timing.Serialize()));

            return stringBuilder.ToString();
        }

        private static string SerializeSongs(IReadOnlyDictionary<int, ulong> songs)
        {
            StringBuilder stringBuilder = new();

            return stringBuilder.AddDictionary(songs, Constants.DefaultInnerSeparator).ToString();
        }

        private static IEnumerable<Timing> DesirializeTimings(string timings)
        {
            List<Timing> result = [];

            IReadOnlyList<string> splittedTimings = timings.Split(Environment.NewLine);

            foreach (string timing in splittedTimings)
            {
                if (string.IsNullOrEmpty(timing)) continue;

                result.Add(TimingExtension.FromString(timing));
            }

            return result;
        }

        private static IReadOnlyDictionary<int, ulong> DesirializeSongs(string songs)
        {
            Dictionary<int, ulong> result = [];

            IReadOnlyList<string> splttedSongs = songs.Split(Environment.NewLine);

            foreach (string pair in splttedSongs)
            {
                if (string.IsNullOrEmpty(pair)) continue;

                IReadOnlyList<string> values = pair.Split(Constants.DefaultInnerSeparator);

                result.Add(int.Parse(values[0]), ulong.Parse(values[1]));
            }

            return result;
        }

        private void ConfigManager_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(configManager.PathSettings))
                pathSettings = configManager.PathSettings;
        }
    }
}
