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

            switch (Cache.Cache.SaveCache(localLevels))
            {
                case Cache.SaveCacheResult.Success:
                    return true;

                case Cache.SaveCacheResult.Fail:
                    return false;

                case Cache.SaveCacheResult.AlreadySaved:
                    return true;

                default: return false;
            }
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
