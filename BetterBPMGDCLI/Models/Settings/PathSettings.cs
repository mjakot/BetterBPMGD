namespace BetterBPMGDCLI.Models.Settings
{
    public class PathSettings : IPathSettings
    {
        public string AppDataFolderPath => throw new NotImplementedException();

        public string BetterBPMGDFolderPath => throw new NotImplementedException();

        public string GeometryDashSavesFolderPath => throw new NotImplementedException();

        public string TimingProjectsFolderPath => throw new NotImplementedException();

        public string TimingsListPath => throw new NotImplementedException();

        public object GetDefault(string propertyName)
        {
            throw new NotImplementedException();
        }

        public string GetSongPathById(int id)
        {
            throw new NotImplementedException();
        }

        public string GetTimingProjectFolderPath(string projectName)
        {
            throw new NotImplementedException();
        }

        public void ResetAll()
        {
            throw new NotImplementedException();
        }
    }
}
