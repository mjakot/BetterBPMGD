namespace BetterBPMGD.Models
{
    public class Settings
    {
        public bool IncludeSpeedPortals { get; set; }
        public bool UndogeableSpeedPortals { get; set; }
        public int FollowGroupId { get; set; }
        public string SavePath { get; set; }
        public SaveTypes SaveType { get; set; }
        public Themes Theme { get; set; }

        public Settings()
        {
            IncludeSpeedPortals = false;
            UndogeableSpeedPortals = false;
            FollowGroupId = 0;
            SavePath = string.Empty;
            SaveType = SaveTypes.GamesSaveFile;
            Theme = Themes.Default;
        }
    }
}
