using System.Xml;

namespace BetterBPMGDCLI.Models.Cache
{
    public class Cache
    {
        //TODO: get path from settings
        private readonly string CachePath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\cache.xml";

        public static SaveCacheResult SaveCache(XmlDocument xmlCache)
        {
            string stringCahche = string.Empty;

            using (var stringWriter = new StringWriter())
            using (var xmlTextWriter = XmlWriter.Create(stringWriter))
            {
                xmlCache.WriteTo(xmlTextWriter);
                xmlTextWriter.Flush();
                stringCahche = stringWriter.GetStringBuilder().ToString();
            }

            return SaveCache(stringCahche);
        }

        public static SaveCacheResult SaveCache(string stringCache) => Save(stringCache);

        public static XmlDocument GetCacheXmlDocument()
        {
            XmlDocument xmlCache = new();

            string stringCache = GetCacheString() ?? string.Empty;

            xmlCache.LoadXml(stringCache);

            return xmlCache;
        }

        public static string? GetCacheString() => Get();

        private static SaveCacheResult Save(string cache)
        {
            if (cache == File.ReadAllText(CachePath)) return SaveCacheResult.AlreadySaved;

            try
            {
                File.WriteAllText(CachePath, cache);

                return SaveCacheResult.Success;
            }
            catch (Exception)
            {
                return SaveCacheResult.Fail;
            }
        }

        private static string? Get()
        {
            return string.Empty;
        }
    }
}
