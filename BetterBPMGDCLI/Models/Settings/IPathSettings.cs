namespace BetterBPMGDCLI.Models.Settings
{
    public interface IPathSettings : ISettings
    {
        string AppDataFolderPath { get; }
        string BetterBPMGDFolderPath { get; }
        string GeometryDashSavesFolderPath { get; }
        string TimingProjectsFolderPath { get; }

        string TimingsListPath { get; }
        string SongsListPath { get; }

        string GetTimingProjectFolderPath(string projectName);
        string GetSongPathById(string projectName, int id);
        string GetTimingListPath(string projectName);
        string GetSongListPath(string projectName);
    }
}
