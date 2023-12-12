using BetterBPMGDCLI.Extensions;
using BetterBPMGDCLI.Models.LevelsSave.Ciphers;
using BetterBPMGDCLI.Models.LevelsSave.Ciphers.Factories;
using BetterBPMGDCLI.Models.LevelsSave.Level;
using System.Xml;
using System.Xml.Linq;

namespace BetterBPMGDCLI.Models
{
    public class Controller
    {
        //TODO: get this path from settings
        private readonly string DefaulLevelsSavePath = $"{Environment.SpecialFolder.UserProfile}\\AppData\\Local\\GeometryDash\\CCLocalLevels.dat";

        public LocalLevel? Level { get; set; }

        public Controller()
        {
            Level = null;

            Cache.Cache.SaveCache(PrepareCache());
        }

        public bool LoadLocalLevel(string levelKey)
        {
            XmlDocument localLevels = Cache.Cache.GetCacheXmlDocument();

            XElement? xmlLevel = localLevels.ToXDocument().FindLevelByKey(levelKey);

            if (xmlLevel is null) return false;

            Level = new(levelKey.LevelKeyToInt(), xmlLevel);

            return true;
        }

        public bool SaveLocalLevel(string levelKey)
        {
            if (Level is null) return false;

            XmlDocument localLevels = Cache.Cache.GetCacheXmlDocument();

            XElement? xmlLevel = localLevels.ToXDocument().FindLevelByKey(levelKey);

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
            string localLevels = File.ReadAllText(DefaulLevelsSavePath);
            LocalLevelsCipher data = new(localLevels);
            LocalLevelsCipher localLevelsCipher = LocalLevelsCipherFactory.Decode(data);

            return localLevelsCipher.DataString;
        }
    }
}
