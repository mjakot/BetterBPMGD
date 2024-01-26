namespace BetterBPMGDCLI.Models.Settings
{
    public interface IPathSettings : ISettings
    {
        string AppDataFolderPath { get; set; }
        string BetterBPMGDFolderPath { get; set; }
        string GeometryDashSavesFolderPath { get; set; }
        string GeometryDashLevelsSavePath { get; set; }
        string TimingProjectsFolderPath { get; set; }

        string TimingListPath { get; set; }
        string SongListPath { get; set; }

        string GetTimingProjectFolderPath(string projectName);
        string GetSongPathById(string projectName, int id);
        string GetTimingListPath(string projectName);
        string GetSongListPath(string projectName);
    }
}
