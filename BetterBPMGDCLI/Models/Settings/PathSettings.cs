using BetterBPMGDCLI.Extensions;
using BetterBPMGDCLI.Utils;

namespace BetterBPMGDCLI.Models.Settings
{
    public class PathSettings : SettingsBase, IPathSettings
    {
        public const string StartupFilePath = ".\\startup.txt";

        public static readonly string ProgramName = AppDomain.CurrentDomain.FriendlyName;
        public static readonly string GeometryDashName = "GeometryDash";
        public static readonly string TimingProjectFolderName = "Projects";
        public static readonly string TimingsListFileName = "Timings.txt";
        public static readonly string SongsListFileName = "Songs.txt";
        public static readonly string LevelsSaveFileName = "CCLocalLevels.dat";
        public static readonly string MinimalLevelFileName = "MinimalLevel.xml";
        public static readonly string SettingFolderName = "Config";
        public static readonly string CurrentProjectSaveFileName = "CurrentProject.txt";
        public static readonly string BackupFolderName = $"{ProgramName}Backups";

        public static string AppDataFolderPathDefault => Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + '\\';
        public static string BetterBPMGDFolderPathDefault => Path.Combine(AppDataFolderPathDefault, $"{ProgramName}\\");
        public static string SettingsFolderPathDefault => Path.Combine(BetterBPMGDFolderPathDefault, $"{SettingFolderName}\\");
        public static string GeometryDashSavesFolderPathDefault => Path.Combine(AppDataFolderPathDefault, $"{GeometryDashName}\\");
        public static string GeometryDashLevelsSavePathDefault => Path.Combine(GeometryDashSavesFolderPathDefault, $"{LevelsSaveFileName}");
        public static string TimingProjectsFolderPathDefault => Path.Combine(BetterBPMGDFolderPathDefault, $"{TimingProjectFolderName}\\");
        public static string MinimalLevelPathDefault => Path.Combine(BetterBPMGDFolderPathDefault, MinimalLevelFileName);
        public static string CurrentProjectSaveFilePathDefault => Path.Combine(SettingsFolderPathDefault, CurrentProjectSaveFileName);
        public static string BackupFolderPathDefault => Path.Combine(GeometryDashSavesFolderPathDefault, $"{BackupFolderName}\\");
        public static string TimingListPathDefault => TimingsListFileName;
        public static string SongListPathDefault => SongsListFileName;

        public string AppDataFolderPath { get; set; }
        public string BetterBPMGDFolderPath { get; set; }
        public string SettingsFolderPath { get; set; }
        public string GeometryDashSavesFolderPath { get; set; }
        public string GeometryDashLevelsSavePath { get; set; }
        public string BackupFolderPath { get; set; }
        public string TimingProjectsFolderPath { get; set; }
        public string CurrentProjectSaveFilePath { get; set; }
        public string TimingListPath { get; set; }
        public string SongListPath { get; set; }
        public string MinimalLevelPath { get; set; }

        public PathSettings() : this(appDataFolderPath: AppDataFolderPathDefault,
                                      betterBPMGDFolderPath: BetterBPMGDFolderPathDefault,
                                      betterBPMGDSettingsFolderPath: SettingsFolderPathDefault,
                                      backupFolderPath: BackupFolderPathDefault,
                                      geometryDashSavesFolderPath: GeometryDashSavesFolderPathDefault,
                                      geometryDashLevelsSavePath: GeometryDashLevelsSavePathDefault,
                                      timingProjectsFolderPath: TimingProjectsFolderPathDefault,
                                      timingsListPath: TimingListPathDefault,
                                      currentProjectSaveFilePath: CurrentProjectSaveFilePathDefault,
                                      songsListPath: SongListPathDefault,
                                      minimalLevelPath: MinimalLevelPathDefault) { }

        public PathSettings(string appDataFolderPath,
                             string betterBPMGDFolderPath,
                             string betterBPMGDSettingsFolderPath,
                             string geometryDashSavesFolderPath,
                             string geometryDashLevelsSavePath,
                             string timingProjectsFolderPath,
                             string timingsListPath,
                             string currentProjectSaveFilePath,
                             string songsListPath,
                             string minimalLevelPath,
                             string backupFolderPath)
        {
            AppDataFolderPath = appDataFolderPath;
            BetterBPMGDFolderPath = betterBPMGDFolderPath;
            SettingsFolderPath = betterBPMGDSettingsFolderPath;
            GeometryDashSavesFolderPath = geometryDashSavesFolderPath;
            GeometryDashLevelsSavePath = geometryDashLevelsSavePath;
            TimingProjectsFolderPath = timingProjectsFolderPath;
            TimingListPath = timingsListPath;
            SongListPath = songsListPath;
            MinimalLevelPath = minimalLevelPath;
            CurrentProjectSaveFilePath = currentProjectSaveFilePath;
            BackupFolderPath = backupFolderPath;

            defaultValues.Add(nameof(AppDataFolderPath), AppDataFolderPathDefault);
            defaultValues.Add(nameof(BetterBPMGDFolderPath), BetterBPMGDFolderPathDefault);
            defaultValues.Add(nameof(GeometryDashSavesFolderPath), GeometryDashSavesFolderPathDefault);
            defaultValues.Add(nameof(GeometryDashLevelsSavePath), GeometryDashLevelsSavePathDefault);
            defaultValues.Add(nameof(TimingProjectsFolderPath), TimingProjectsFolderPathDefault);
            defaultValues.Add(nameof(TimingListPath), TimingListPathDefault);
            defaultValues.Add(nameof(SongListPath), SongListPathDefault);
            defaultValues.Add(nameof(MinimalLevelPath), MinimalLevelPathDefault);
            defaultValues.Add(nameof(SettingsFolderPath), SettingsFolderPathDefault);
            defaultValues.Add(nameof(CurrentProjectSaveFilePath), CurrentProjectSaveFilePathDefault);
        }

        public static string GetSerializationPath<T>(T pathSettings) where T : SettingsBase, IPathSettings, new()
            => Path.ChangeExtension(Path.Combine(pathSettings.SettingsFolderPath, nameof(IPathSettings)), Constants.TXTExtension);

        public static new PathSettings FromString(string settings) => settings.Desirialize<PathSettings>(false);

        public override string ToString() => this.Serialize(false);

        public string GetTimingProjectFolderPath(string projectName)
        {
            if (!projectName.Contains('\\'))
                projectName += '\\';

            return Path.Combine(TimingProjectsFolderPath, projectName);
        }

        public string GetSongPathById(string projectName, int id) => Path.Combine(GetTimingProjectFolderPath(projectName), $"{id}.mp3");

        public string GetTimingListPath(string projectName) => Path.Combine(GetTimingProjectFolderPath(projectName), TimingsListFileName);

        public string GetSongListPath(string projectName) => Path.Combine(GetTimingProjectFolderPath(projectName), SongsListFileName);
    }
}
