using BetterBPMGDCLI.Extensions;

namespace BetterBPMGDCLI.Models.Settings
{
    public class PathSettings : SettingsBase, IPathSettings
    {
        public static readonly string ProgramName = AppDomain.CurrentDomain.FriendlyName;
        public static readonly string GeometryDashName = "GeometryDash";
        public static readonly string TimingProjectFolderName = "Projects";
        public static readonly string TimingsListFileName = "Timings.txt";
        public static readonly string SongsListFileName = "Songs.txt";
        public static readonly string LevelsSaveFileName = "CCLocalLevels.dat";
        public static readonly string MinimalLevelFileName = "MinimalLevel.xml";

        public static string AppDataFolderPathDefault => Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        public static string BetterBPMGDFolderPathDefault => Path.Combine(AppDataFolderPathDefault, $"{ProgramName}\\");
        public static string GeometryDashSavesFolderPathDefault => Path.Combine(AppDataFolderPathDefault, $"{GeometryDashName}\\");
        public static string GeometryDashLevelsSavePathDefault => Path.Combine(GeometryDashSavesFolderPathDefault, $"{LevelsSaveFileName}\\");
        public static string TimingProjectsFolderPathDefault => Path.Combine(BetterBPMGDFolderPathDefault, $"{TimingProjectFolderName}\\");
        public static string MinimalLevelPathDefault => Path.Combine(BetterBPMGDFolderPathDefault, MinimalLevelFileName);
        public static string TimingListPathDefault => TimingsListFileName;
        public static string SongListPathDefault => TimingsListFileName;

        public string AppDataFolderPath { get; set; }
        public string BetterBPMGDFolderPath { get; set; }
        public string GeometryDashSavesFolderPath { get; set; }
        public string GeometryDashLevelsSavePath { get; set; }
        public string TimingProjectsFolderPath { get; set; }
        public string TimingListPath { get; set; }
        public string SongListPath { get; set; }
        public string MinimalLevelPath { get; set; }

        public PathSettings() : this(AppDataFolderPathDefault, BetterBPMGDFolderPathDefault, GeometryDashSavesFolderPathDefault, GeometryDashLevelsSavePathDefault, TimingProjectsFolderPathDefault, TimingListPathDefault, SongListPathDefault, MinimalLevelPathDefault) { }

        public PathSettings(string appDataFolderPath, string betterBPMGDFolderPath, string geometryDashSavesFolderPath, string geometryDashLevelsSavePath, string timingProjectsFolderPath, string timingsListPath, string songsListPath, string minimalLevelPath)
        {
            AppDataFolderPath = appDataFolderPath;
            BetterBPMGDFolderPath = betterBPMGDFolderPath;
            GeometryDashSavesFolderPath = geometryDashSavesFolderPath;
            GeometryDashLevelsSavePath = geometryDashLevelsSavePath;
            TimingProjectsFolderPath = timingProjectsFolderPath;
            TimingListPath = timingsListPath;
            SongListPath = songsListPath;
            MinimalLevelPath = minimalLevelPath;

            defaultValues.Add(nameof(AppDataFolderPath), AppDataFolderPathDefault);
            defaultValues.Add(nameof(BetterBPMGDFolderPath), BetterBPMGDFolderPathDefault);
            defaultValues.Add(nameof(GeometryDashSavesFolderPath), GeometryDashSavesFolderPathDefault);
            defaultValues.Add(nameof(GeometryDashLevelsSavePath), GeometryDashLevelsSavePathDefault);
            defaultValues.Add(nameof(TimingProjectsFolderPath), TimingProjectsFolderPathDefault);
            defaultValues.Add(nameof(TimingListPath), TimingListPathDefault);
            defaultValues.Add(nameof(SongListPath), SongListPathDefault);
            defaultValues.Add(nameof(MinimalLevelPath), MinimalLevelPathDefault);
        }

        public static new PathSettings FromString(string settings) => settings.Desirialize<PathSettings>(false);

        public override string ToString() => this.Serialize(false);

        public string GetTimingProjectFolderPath(string projectName)
        {
            if (!projectName.Contains('\\')) projectName += '\\';

            return Path.Combine(TimingProjectsFolderPath, projectName);
        }

        public string GetSongPathById(string projectName, int id)
        {
            string path = GetTimingProjectFolderPath(projectName);
            string name = $"{id}.mp3";

            return Path.Combine(path, name);
        }

        public string GetTimingListPath(string projectName)
        {
            string path = GetTimingProjectFolderPath(projectName);

            return Path.Combine(path, TimingsListFileName);
        }

        public string GetSongListPath(string projectName)
        {
            string path = GetTimingProjectFolderPath(projectName);

            return Path.Combine(path, SongsListFileName);
        }
    }
}
