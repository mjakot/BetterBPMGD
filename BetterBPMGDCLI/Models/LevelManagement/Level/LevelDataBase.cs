namespace BetterBPMGDCLI.Models.LevelManagement.Level
{
    public abstract class LevelDataBase : ILevelData
    {
        public abstract string Encode();
        public static ILevelData? Parse(string data) => null;
    }
}
