using BetterBPMGDCLI.Extensions;
using System.Text;

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

        public string AppDataFolderPath => Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

        public string BetterBPMGDFolderPath => Path.Combine(AppDataFolderPath, $"{ProgramName}\\");

        public string GeometryDashSavesFolderPath => Path.Combine(AppDataFolderPath, $"{GeometryDashName}\\");

        public string TimingProjectsFolderPath => Path.Combine(BetterBPMGDFolderPath, $"{TimingProjectFolderName}\\");

        public string TimingsListPath => TimingsListFileName;

        public string SongsListPath => SongsListFileName;

        public new SettingsBase FromString(string settings)
        {
            IReadOnlyList<string> splittedSettings = settings.Split(Environment.NewLine);
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new();

            stringBuilder.AddKeyValuePair(AppDataFolderPathKey, AppDataFolderPath, Separator);
            stringBuilder.AddKeyValuePair(BetterBPMGDFolderPathKey, BetterBPMGDFolderPath, Separator);
            stringBuilder.AddKeyValuePair(GeometryDashSavesFolderPath, GeometryDashSavesFolderPath, Separator);
            stringBuilder.AddKeyValuePair(TimingProjectsFolderPathKey, TimingProjectsFolderPath, Separator);
            stringBuilder.AddKeyValuePair(TimingsListPathKey, TimingsListPath, Separator);
            stringBuilder.AddKeyValuePair(SongsListPathKey, SongsListPath, Separator);

            return stringBuilder.ToString();
        }

        public override object GetDefault(string propertyName)
        {
            throw new NotImplementedException();
        }

        public override void ResetAll()
        {
            throw new NotImplementedException();
        }

        public string GetSongPathById(string projectName, int id)
        {
            throw new NotImplementedException();
        }

        public string GetSongListPath(string projectName)
        {
            throw new NotImplementedException();
        }

        public string GetTimingListPath(string projectName)
        {
            throw new NotImplementedException();
        }

        public string GetTimingList(string projectName)
        {
            throw new NotImplementedException();
        }

        public string GetSongList(string projectName)
        {
            throw new NotImplementedException();
        }

        public string GetTimingProjectFolderPath(string projectName)
        {
            throw new NotImplementedException();
        }
    }
}
