using BetterBPMGDCLI.Extensions;
using BetterBPMGDCLI.Models.LevelsSave.Ciphers;
using BetterBPMGDCLI.Models.LevelsSave.Ciphers.Factories;
using BetterBPMGDCLI.Models.LevelsSave.Level;
using BetterBPMGDCLI.Models.Settings;
using System.Xml.Linq;

namespace BetterBPMGDCLI.Models
{
    public class Controller
    {
        private readonly ISettings settings;

        public LocalLevel? Level { get; set; }

        public Controller(ISettings settings)
        {
            this.settings = settings;

            Level = null;

            Cache.Cache.AddSettings(settings);
            Cache.Cache.SaveCache(PrepareCache());
        }

        public async Task<bool> LoadLocalLevelAsync(string levelKey)
        {
            XDocument localLevels = await Cache.Cache.GetCacheXDocumentAsync() ?? new();

            XElement? xmlLevel = localLevels.FindLevelByKey(levelKey);

            if (xmlLevel is null) return false;

            Level = new(levelKey.LevelKeyToInt(), xmlLevel);

            return true;
        }

        public async Task<bool> SaveLocalLevelAsync(string levelKey)
        {
            if (Level is null) return false;

            XDocument localLevels = await Cache.Cache.GetCacheXDocumentAsync() ?? new();

            XElement? xmlLevel = localLevels.FindLevelByKey(levelKey);

            xmlLevel?.ToXDocument().ModifyElementValue("k", "k4", "s", Level!.LevelData.Encode(true));

            return Cache.Cache.SaveCache(localLevels) switch
            {
                Cache.SaveCacheResult.Success => true,
                Cache.SaveCacheResult.Fail => false,
                Cache.SaveCacheResult.AlreadySaved => true,
                _ => false,
            };
        }

        private string PrepareCache()
        {
            string localLevels = File.ReadAllText(settings.LevelsSavePath);
            LocalLevelsCipher data = new(localLevels);
            LocalLevelsCipher localLevelsCipher = LocalLevelsCipherFactory.Decode(data);

            return localLevelsCipher.DataString;
        }
    }
}
