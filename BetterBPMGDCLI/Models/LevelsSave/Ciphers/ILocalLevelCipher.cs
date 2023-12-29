namespace BetterBPMGDCLI.Models.LevelsSave.Ciphers
{
    public interface ILocalLevelCipher
    {
        string DataString { get; }
        byte[] DataByteArray { get; }
    }
}
