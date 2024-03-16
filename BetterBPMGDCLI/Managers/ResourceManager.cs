namespace BetterBPMGDCLI.Managers
{
    public class ResourceManager<TypeNameResource>(string resourceType)
    {
        private readonly System.Resources.ResourceManager resourceManager = new($"BetterBPMGDCLI.Resources.{resourceType}.{typeof(TypeNameResource).Name}",
                                                                                        typeof(TypeNameResource).Assembly);

        public string GetString(string key) => resourceManager.GetString(key) ?? string.Empty;

        public string[] GetStringArray(string key) => GetString(key)
                                                        .Replace(" ", string.Empty)
                                                        .Split(',');

        public static string GetString<StaticTypeName>(string key, string resourceType)
        {
            System.Resources.ResourceManager resourceManager = new($"BetterBPMGDCLI.Resources.{resourceType}.{typeof(StaticTypeName).Name}", typeof(StaticTypeName).Assembly);

            return resourceManager.GetString(key) ?? string.Empty;
        }

        public static string[] GetStringArray<StaticTypeName>(string key, string resourceType) => GetString<StaticTypeName>(key, resourceType).Replace(" ", string.Empty)
                                                                                                                                                .Split(',');
    }
}
