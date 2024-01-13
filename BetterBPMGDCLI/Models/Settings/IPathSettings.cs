namespace BetterBPMGDCLI.Models.Settings
{
    public interface IPathSettings : ISettings
    {
        string AppDataFolderPath { get; set; }
        string BetterBPMGDFolderPath { get; set; }
        string GeometryDashSavesFolderPath { get; set; }
        string TimingProjectsFolderPath { get; set; }

        string TimingsListPath { get; set; }
        string SongsListPath { get; set; }

        string GetTimingProjectFolderPath(string projectName);
        string GetSongPathById(string projectName, int id);
        string GetTimingListPath(string projectName);
        string GetSongListPath(string projectName);
    }
}
