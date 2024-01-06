namespace BetterBPMGDCLI.Models.LevelsSave.Ciphers
{
    public interface ILocalLevelCipher
    {
        string DataString { get; set; }
        byte[] DataByteArray { get; set; }
        string Decode();
    }
}
