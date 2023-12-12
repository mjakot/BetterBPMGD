namespace BetterBPMGDCLI.Extensions
{
    public static class StringExtension
    {
        public static int LevelKeyToInt(this string value) => int.Parse(value.Replace("k_", string.Empty));
    }
}
