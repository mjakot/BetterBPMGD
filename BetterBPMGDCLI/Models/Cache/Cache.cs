using BetterBPMGDCLI.Models.Settings;
using System.Xml;
using System.Xml.Linq;

namespace BetterBPMGDCLI.Models.Cache
{
    public class Cache
    {
        private static ISettings? settings;

        public static void AddSettings(ISettings implementation) => settings = implementation;

        public static SaveCacheResult SaveCache(XDocument xCache) => SaveCache(xCache.ToString());

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

        public static async Task<SaveCacheResult> SaveCacheAsync(XDocument xCache) => await SaveCacheAsync(xCache.ToString());

        public static async Task<SaveCacheResult> SaveCacheAsync(XmlDocument xmlCache)
        {
            string stringCahche = string.Empty;

            using (var stringWriter = new StringWriter())
            using (var xmlTextWriter = XmlWriter.Create(stringWriter))
            {
                xmlCache.WriteTo(xmlTextWriter);
                xmlTextWriter.Flush();
                stringCahche = stringWriter.GetStringBuilder().ToString();
            }

            return await SaveCacheAsync(stringCahche);
        }

        public static async Task<SaveCacheResult> SaveCacheAsync(string stringCache) => await SaveAsync(stringCache);

        public static XDocument? GetCacheXDocument()
        {
            if (settings is null) return null;

            return XDocument.Load(settings.CachePath);
        }

        public static XmlDocument GetCacheXmlDocument()
        {
            XmlDocument xmlCache = new();

            string stringCache = GetCacheString() ?? string.Empty;

            xmlCache.LoadXml(stringCache);

            return xmlCache;
        }

        public static string? GetCacheString() => Get();

        public static async Task<XDocument?> GetCacheXDocumentAsync()
        {
            if (settings is null) return null;

            return await Task.Run(() => XDocument.Load(settings.CachePath));
        }

        public static async Task<XmlDocument> GetCacheXmlDocumentAsync()
        {
            XmlDocument xmlCache = new();

            string stringCache = await GetCacheStringAsync() ?? string.Empty;

            xmlCache.LoadXml(stringCache);

            return xmlCache;
        }

        public static async Task<string?> GetCacheStringAsync() => await GetAsync();

        private static SaveCacheResult Save(string cache)
        {
            if (settings is null) return SaveCacheResult.Fail;

            if (cache == File.ReadAllText(settings.CachePath)) return SaveCacheResult.AlreadySaved;

            try
            {
                File.WriteAllText(settings.CachePath, cache);

                return SaveCacheResult.Success;
            }
            catch (Exception)
            {
                return SaveCacheResult.Fail;
            }
        }

        private static async Task<SaveCacheResult> SaveAsync(string cache)
        {
            if (settings is null) return SaveCacheResult.Fail;

            if (cache == File.ReadAllText(settings.CachePath)) return SaveCacheResult.AlreadySaved;

            try
            {
                await File.WriteAllTextAsync(settings.CachePath, cache);

                return SaveCacheResult.Success;
            }
            catch (Exception)
            {
                return SaveCacheResult.Fail;
            }
        }

        private static string? Get()
        {
            if (settings is null) return null;

            try
            {
                return File.ReadAllText(settings.CachePath);
            }
            catch (Exception)
            {
                return null;
            }
        }

        private static async Task<string?> GetAsync()
        {
            if (settings is null) return null;

            try
            {
                return await File.ReadAllTextAsync(settings.CachePath);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
