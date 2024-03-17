using BetterBPMGDCLI.Extensions;
using BetterBPMGDCLI.Managers;
using BetterBPMGDCLI.Models.Level;
using BetterBPMGDCLI.Models.Settings;
using BetterBPMGDCLI.Utils;
using Common;
using NAudio.Wave;
using System.ComponentModel;
using System.Text;
using System.Xml.Linq;

namespace BetterBPMGDCLI.Models.TimingProject
{
    public class Project : IDisposable
    {
        private readonly ConfigManager configManager;
        private IPathSettings pathSettings;

        private readonly Dictionary<int, ulong> songIds;
        private readonly List<Timing> timings;

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
        public Project(ConfigManager configManager, string name, IReadOnlyDictionary<int, ulong> songIdsIn, IEnumerable<Timing> timingsIn)
        {
            this.configManager = configManager;
            pathSettings = configManager.PathSettings;
            Name = name;
            songIds = [];
            timings = [];

            AddSongs(songIdsIn);
            AddTimings(timingsIn);

            configManager.PropertyChanged += ConfigManager_PropertyChanged;
        }

        public void Dispose()
        {
            if (string.IsNullOrEmpty(Name))
                return;

            string projectPath = pathSettings.GetTimingProjectFolderPath(Name);

            File.WriteAllText(Path.Combine(projectPath, pathSettings.SongListPath), SerializeSongs(SongIds));
            File.WriteAllText(Path.Combine(projectPath, pathSettings.TimingListPath), SerializeTimings(Timings));

            GC.SuppressFinalize(this);
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

        public static Project ReadProject(ConfigManager config, string projectName)
            => ReadProject(config, config.PathSettings.GetTimingProjectFolderPath(projectName), config.PathSettings.SongListPath, config.PathSettings.TimingListPath);

        public static Project ReadProject(ConfigManager config, string projectFolderPath, string songsListFileName, string timingsListFileName)
        {
            if (!Path.HasExtension(songsListFileName))
                songsListFileName += Path.ChangeExtension(songsListFileName, Constants.MP3Extension);

            if (!Path.HasExtension(timingsListFileName))
                timingsListFileName += Path.ChangeExtension(timingsListFileName, Constants.MP3Extension);

            string songsListPath = Path.Combine(projectFolderPath, songsListFileName);
            string timingsListPath = Path.Combine(projectFolderPath, timingsListFileName);

            string name = Path.GetFileName(Path.GetDirectoryName(projectFolderPath) ?? string.Empty);
            string songs = File.ReadAllText(songsListPath);
            string timings = File.ReadAllText(timingsListPath);

            Project result = new(config, name, DesirializeSongs(songs), DesirializeTimings(timings));

            return result;
        }

        public void SaveProject()
        {
            string serializedTimings = SerializeTimings(timings);
            string serializedSongs = SerializeSongs(songIds);

            File.WriteAllText(pathSettings.GetTimingListPath(Name), serializedTimings);
            File.WriteAllText(pathSettings.GetSongListPath(Name), serializedSongs);
        }

        public void InjectTimings(LocalLevel level)
        {
            IOrderedEnumerable<KeyValuePair<int, ulong>> orderedSongIds = songIds.OrderBy(pair => pair.Value);

            KeyValuePair<int, ulong> lastSong = orderedSongIds.LastOrDefault();

            using Mp3FileReader reader = new(Path.Combine(pathSettings.GetTimingProjectFolderPath(Name),
                                              Path.ChangeExtension(lastSong.Key.ToString(),
                                              Constants.MP3Extension)));

            ulong duration = (ulong)reader.TotalTime.TotalMilliseconds;

            InjectSongs(level.XmlLevel, orderedSongIds.FirstOrDefault());

            level.LevelData?.Calculate(timings, duration + lastSong.Value);
        }

        private static void InitializeProject(ConfigManager config, string projectName, int initialSongId)
        {
            string projectPath = config.PathSettings.GetTimingProjectFolderPath(projectName);
            string initialSongPath = Path.Combine(config.PathSettings.GeometryDashSavesFolderPath, Path.ChangeExtension(initialSongId.ToString(), Constants.MP3Extension));

            if (File.Exists(initialSongPath)) //TODO: something something error handling something something
            {
                Directory.CreateDirectory(projectPath);

                File.Copy(initialSongPath, Path.Combine(projectPath, Path.GetFileName(initialSongPath)), true);

                File.WriteAllText(config.PathSettings.GetTimingListPath(projectName), string.Empty);
                File.WriteAllText(config.PathSettings.GetSongListPath(projectName), string.Empty);
            }
        }

        private static string SerializeTimings(IReadOnlyList<Timing> timings)
        {
            StringBuilder stringBuilder = new();

            foreach (Timing timing in timings)
                stringBuilder.AppendLine(timing.Serialize());

            return stringBuilder.ToString();
        }

        private static string SerializeSongs(IReadOnlyDictionary<int, ulong> songs) => new StringBuilder().AddDictionary(songs, Constants.DefaultInnerSeparator).ToString();

        private static List<Timing> DesirializeTimings(string timings)
        {
            List<Timing> result = [];

            IReadOnlyList<string> splittedTimings = timings.Split(Environment.NewLine);

            foreach (string timing in splittedTimings)
            {
                if (string.IsNullOrEmpty(timing))
                    continue;

                result.Add(TimingExtension.FromString(timing));
            }

            return result;
        }

        private static Dictionary<int, ulong> DesirializeSongs(string songs)
        {
            Dictionary<int, ulong> result = [];

            IReadOnlyList<string> splttedSongs = songs.Split(Environment.NewLine);

            foreach (string pair in splttedSongs)
            {
                if (string.IsNullOrEmpty(pair))
                    continue;

                IReadOnlyList<string> values = pair.Split(Constants.DefaultInnerSeparator);

                result.Add(int.Parse(values[0]), ulong.Parse(values[1]));
            }

            return result;
        }

        private static void InjectSongs(XElement level, KeyValuePair<int, ulong> song)
        {
            XElement? customSong = level.FindElementByKeyValue("k45", Constants.IntegerElementTag);

            if (customSong is not null)
                customSong.Value = song.Key.ToString();
        }

        private void ConfigManager_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(configManager.PathSettings))
                pathSettings = configManager.PathSettings;
        }
    }
}
