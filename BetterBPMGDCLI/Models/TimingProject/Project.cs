using BetterBPMGDCLI.Extensions;
using BetterBPMGDCLI.Models.Level;
using BetterBPMGDCLI.Models.Settings;
using BetterBPMGDCLI.Utils;
using Common;
using NAudio.Wave;
using System.Text;

namespace BetterBPMGDCLI.Models.TimingProject
{
    public class Project
    {
        private const string MP3Extension = ".mp3";

        private readonly IPathSettings pathSettings;

        private Dictionary<int, ulong> songIds;
        private List<Timing> timings;

        public string Name { get; set; }
        public IReadOnlyDictionary<int, ulong> SongIds => songIds;
        public IReadOnlyList<Timing> Timings => timings;

        public Project(IPathSettings settings) : this(settings, string.Empty, -1) { }

        public Project(IPathSettings settings, string name, int songId, ulong songOffsetMS = 0)
        {
            pathSettings = settings;
            Name = name;
            songIds = new() { { songId, songOffsetMS } };
            timings = [];
        }

        public void AddSong(int id, ulong offset) => songIds.Add(id, offset);
        public void AddSongs(IReadOnlyDictionary<int, ulong> songs)
        {
            Parallel.ForEach(songs, song => songIds.Add(song.Key, song.Value));
        }

        public void AddTiming(Timing timing) => timings.Add(timing);
        public void AddTimings(IEnumerable<Timing> timings) => this.timings.AddRange(timings);

        public void ClearSongs() => songIds.Clear();

        public void ClearTimings() => timings.Clear();

        public static Project CreateNew(IPathSettings settings, string projectName, int initialSongId, ulong songOffsetMS = 0)
        {
            InitializeProject(settings, projectName, initialSongId);

            return new(settings, projectName, initialSongId, songOffsetMS);
        }

        public static Project ReadProject(IPathSettings settings, string projectName) => ReadProject(settings, settings.GetTimingProjectFolderPath(projectName), settings.SongListPath, settings.TimingListPath);

        public static Project ReadProject(IPathSettings settings, string projectFolderPath, string songsListFileName, string timingsListFileName)
        {
            if (!Path.HasExtension(songsListFileName)) songsListFileName += Path.ChangeExtension(songsListFileName, MP3Extension);
            if (!Path.HasExtension(timingsListFileName)) timingsListFileName += Path.ChangeExtension(timingsListFileName, MP3Extension);

            string songsListPath = Path.Combine(projectFolderPath, songsListFileName);
            string timingsListPath = Path.Combine(projectFolderPath, timingsListFileName);

            string name = Path.GetFileName(Path.GetDirectoryName(projectFolderPath) ?? string.Empty);
            string songs = FileUtility.ReadFromFile(songsListPath);
            string timings = FileUtility.ReadFromFile(timingsListPath);

            Project result = new(settings) { Name = name };

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

            using Mp3FileReader reader = new(Path.Combine(pathSettings.GetTimingProjectFolderPath(Name), Path.ChangeExtension(lastSong.Key.ToString(), MP3Extension)));

            ulong duration = (ulong)reader.TotalTime.TotalMicroseconds;

            level.LevelData?.Calculate(timings, duration + lastSong.Value);
        }

        private static void InitializeProject(IPathSettings settings, string projectName, int initialSongId)
        {
            string projectPath = settings.GetTimingProjectFolderPath(projectName);
            string initialSongPath = Path.Combine(settings.GeometryDashSavesFolderPath, Path.ChangeExtension(initialSongId.ToString(), MP3Extension));

            FileUtility.CreateNewFolder(projectPath);
            FileUtility.CopyFile(initialSongPath, Path.Combine(projectPath, Path.GetFileName(initialSongPath)));
            FileUtility.WriteToFile(settings.GetTimingListPath(projectName), string.Empty);
            FileUtility.WriteToFile(settings.GetSongListPath(projectName), string.Empty);
        }

        private static string SerializeTimings(IReadOnlyList<Timing> timings)
        {
            StringBuilder stringBuilder = new();

            Parallel.ForEach(timings, timing => stringBuilder.AppendLine(timing.ToString()));

            return stringBuilder.ToString();
        }

        private static string SerializeSongs(IReadOnlyDictionary<int, ulong> songs)
        {
            StringBuilder stringBuilder = new();

            return stringBuilder.AddDictionary(songs, Serializer.DefaultInnerSeparator).ToString();
        }

        private static IEnumerable<Timing> DesirializeTimings(string timings)
        {
            List<Timing> result = [];

            IReadOnlyList<string> splittedTimings = timings.Split(Environment.NewLine);

            Parallel.ForEach(splittedTimings, timing => result.Add(TimingExtension.FromString(timing)));

            return result;
        }

        private static IReadOnlyDictionary<int, ulong> DesirializeSongs(string songs)
        {
            Dictionary<int, ulong> result = [];

            IReadOnlyList<string> splttedSongs = songs.Split(Environment.NewLine);

            Parallel.ForEach(splttedSongs, pair =>
            {
                IReadOnlyList<string> values = pair.Split(Serializer.DefaultInnerSeparator);

                result.Add(int.Parse(values[0]), ulong.Parse(values[1]));
            });

            return result;
        }
    }
}
