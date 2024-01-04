using BetterBPMGDCLI.Extensions;
using BetterBPMGDCLI.Models.FileManagement;
using BetterBPMGDCLI.Models.LevelsSave.Ciphers.Factories;
using BetterBPMGDCLI.Models.LevelsSave.Level;
using BetterBPMGDCLI.Models.Settings.Interfaces;
using Common;

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

        public bool CreateNewProject(string projectName, ulong songId) => fileManager.CreateNewProject(projectName, songId);

        public bool AddTiming(string projectName, Timing timing) => fileManager.AddTiming(projectName, timing);

        public bool AddTimings(string projectName, IEnumerable<Timing> timings) => fileManager.AddTimings(projectName, timings);

        public bool InjectTimings(string projectName, string levelKey = "k_0", string levelName = "newLevel")
        {
            ILocalLevelCipherFactory localLevelCipherFactory = new LocalLevelsCipherFactory();
            ILocalLevelCipherFactory localLevelDataCipherFactory = new LocalLevelDataCipherFactory();

            bool result = fileManager.CopyLocalLevels();
            result &= fileManager.DecryptLocalLevels(localLevelCipherFactory);

            if (settings.CreateNewLevel) result &= fileManager.CreateNewLevel(levelKey);
            else result &= fileManager.FindLocalLevel(levelName);

            level = fileManager.GetLocalLevel(localLevelDataCipherFactory);

            if (level is null) return false;

            IEnumerable<Timing> timings = TimingExtension.Sort(fileManager.GetTimings(projectName) ?? []);

            level.Add(timings);
            level.SongDurationMS = 10000000;
            level.Encode(true);

            result &= fileManager.SaveLocalLevel(level ?? new(string.Empty, string.Empty));

            result &= fileManager.InsertLocalLevel();

            return result &= fileManager.UpdateLocalLevels();
        }
    }
}
 