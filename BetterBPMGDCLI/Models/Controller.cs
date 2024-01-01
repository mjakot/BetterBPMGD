using BetterBPMGDCLI.Models.FileManagement;
using BetterBPMGDCLI.Models.LevelsSave.Ciphers.Factories;
using BetterBPMGDCLI.Models.LevelsSave.Level;
using BetterBPMGDCLI.Models.Settings.Interfaces;

namespace BetterBPMGDCLI.Models
{
    public class Controller
    {
        private IControllerSettings settings;

        private FileManager fileManager;

        public LocalLevelData? level { get; private set; }

        public Controller(IFileManagerSettings fileManagerSettings, IControllerSettings settings)
        {
            this.settings = settings;

            fileManager = new FileManager(fileManagerSettings);
        }

        public bool Begin(string levelID = "k_0")
        {
            bool result = fileManager.CopyLocalLevels();

            result &= fileManager.DecryptLocalLevels(new LocalLevelsCipherFactory());

            if (settings.CreateNewLevel) result &= fileManager.CreateNewLevel(levelID);
            else result &= fileManager.FindLocalLevel(levelID);

            level = fileManager.GetLocalLevel(new LocalLevelDataCipherFactory());

            return result;
        }

        public bool End()
        {
            if (level is null) return false;

            bool result = fileManager.SaveLocalLevel(level);

            result &= fileManager.InsertLocalLevel();

            return result &= fileManager.UpdateLocalLevels();
        }
    }
}
