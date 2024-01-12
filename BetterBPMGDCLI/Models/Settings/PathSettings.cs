namespace BetterBPMGDCLI.Models.Settings
{
    public class PathSettings : IPathSettings
    {
        public string AppDataFolderPath => throw new NotImplementedException();

        public string BetterBPMGDFolderPath => throw new NotImplementedException();

        public string GeometryDashSavesFolderPath => throw new NotImplementedException();

        public string TimingProjectsFolderPath => throw new NotImplementedException();

        public string TimingsListPath => throw new NotImplementedException();

        public string SongsListPath => throw new NotImplementedException();

        public object GetDefault(string propertyName)
        {
            throw new NotImplementedException();
        }

        public string GetSongList(string projectName)
        {
            throw new NotImplementedException();
        }

        public string GetSongListPath(string projectName)
        {
            throw new NotImplementedException();
        }

        public string GetSongPathById(string projectName, int id)
        {
            throw new NotImplementedException();
        }

        public string GetTimingList(string projectName)
        {
            throw new NotImplementedException();
        }

        public string GetTimingListPath(string projectName)
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
