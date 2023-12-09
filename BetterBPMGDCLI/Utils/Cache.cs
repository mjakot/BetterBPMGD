using System.Xml;

namespace BetterBPMGDCLI.Utils
{
    public class Cache
    {
        public static SaveCacheResult SaveCache(XmlDocument xmlCache)
        {
            Save();
        }

        public static SaveCacheResult SaveCache(string stringCache)
        {
            Save();
        }

        private static bool Save()
        {
            throw new NotImplementedException();
        }
    }
}
