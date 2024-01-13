using BetterBPMGDCLI.Extensions;

namespace BetterBPMGDCLI.Models.Settings
{
    public class PathSettings : SettingsBase, IPathSettings
    {
        public const string Separator = "=";

        public const string AppDataFolderPathKey = "appdataFolder";
        public const string BetterBPMGDFolderPathKey = "programFolder";
        public const string GeometryDashFolderPathKey = "gdFolder";
        public const string TimingProjectsFolderPathKey = "projectsFolder";
        public const string TimingsListPathKey = "timingsPath";
        public const string SongsListPathKey = "songsPath";

        public static readonly string ProgramName = AppDomain.CurrentDomain.FriendlyName;
        public static readonly string GeometryDashName = "GeometryDash";
        public static readonly string TimingProjectFolderName = "Projects";
        public static readonly string TimingsListFileName = "Timings.txt";
        public static readonly string SongsListFileName = "Songs.txt";

        public static string AppDataFolderPathDefault => Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        public static string BetterBPMGDFolderPathDefault => Path.Combine(AppDataFolderPathDefault, $"{ProgramName}\\");
        public static string GeometryDashSavesFolderPathDefault => Path.Combine(AppDataFolderPathDefault, $"{GeometryDashName}\\");
        public static string TimingProjectsFolderPathDefault => Path.Combine(AppDataFolderPathDefault, $"{GeometryDashName}\\");
        public static string TimingsListPathDefault => TimingsListFileName;
        public static string SongsListPathDefault => TimingsListFileName;

        public string AppDataFolderPath { get; set; }
        public string BetterBPMGDFolderPath { get; set; }
        public string GeometryDashSavesFolderPath { get; set; }
        public string TimingProjectsFolderPath { get; set; }
        public string TimingsListPath { get; set; }
        public string SongsListPath { get; set; }

        public PathSettings() : this(AppDataFolderPathDefault, BetterBPMGDFolderPathDefault, GeometryDashSavesFolderPathDefault, TimingProjectsFolderPathDefault, TimingsListPathDefault, SongsListPathDefault) { }

        public PathSettings(string appDataFolderPath, string betterBPMGDFolderPath, string geometryDashSavesFolderPath, string timingProjectsFolderPath, string timingsListPath, string songsListPath)
        {
            AppDataFolderPath = appDataFolderPath;
            BetterBPMGDFolderPath = betterBPMGDFolderPath;
            GeometryDashSavesFolderPath = geometryDashSavesFolderPath;
            TimingProjectsFolderPath = timingProjectsFolderPath;
            TimingsListPath = timingsListPath;
            SongsListPath = songsListPath;
        }

        public static new SettingsBase FromString(string settings) => settings.Desirialize<PathSettings>(false);

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
