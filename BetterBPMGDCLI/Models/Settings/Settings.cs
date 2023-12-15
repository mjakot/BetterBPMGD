namespace BetterBPMGDCLI.Models.Settings
{
    public class Settings : ISettings
    {
        private string levelsSavePath;
        private string cachePath;


        public string DefaultLevelsSavePath => Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\cache.xml";
        public string DefaultCachePath => Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\cache.xml";
        
        public string LevelsSavePath
        {
            get => levelsSavePath;
            set => levelsSavePath = value;
        }

        public string CachePath
        {
            get => cachePath;
            set => cachePath = value;
        }

        public void ResetAllSettings()
        {
            levelsSavePath = DefaultLevelsSavePath;
            CachePath = DefaultCachePath;
        }
    }
}
