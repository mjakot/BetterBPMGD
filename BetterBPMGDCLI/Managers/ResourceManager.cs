namespace BetterBPMGDCLI.Managers
{
    public class ResourceManager<ScopeTypeName>(string resourceType)
    {
        private readonly System.Resources.ResourceManager resourceManager = new($"BetterBPMGDCLI.Resources.{resourceType}.{typeof(ScopeTypeName).Name}",
                                                                                        typeof(ScopeTypeName).Assembly);

        public string GetString(string key) => resourceManager.GetString(key) ?? string.Empty;

        public string[] GetStringArray(string key) => (resourceManager.GetString(key) ?? string.Empty)
                                                        .Replace(" ", string.Empty)
                                                        .Split(',');

        public static string GetString<TypeName>(string key, string resourceType)
        {
            System.Resources.ResourceManager resourceManager = new($"BetterBPMGDCLI.Resources.{resourceType}.{typeof(TypeName).Name}", typeof(TypeName).Assembly);

            return resourceManager.GetString(key) ?? string.Empty;
        }

        public static string[] GetStringArray<TypeName>(string key, string resourceType)
        {
            System.Resources.ResourceManager resourceManager = new($"BetterBPMGDCLI.Resources.{resourceType}.{typeof(TypeName).Name}", typeof(TypeName).Assembly);

            return (resourceManager.GetString(key) ?? string.Empty)
                    .Replace(" ", string.Empty)
                    .Split(',');
        }
    }
}
