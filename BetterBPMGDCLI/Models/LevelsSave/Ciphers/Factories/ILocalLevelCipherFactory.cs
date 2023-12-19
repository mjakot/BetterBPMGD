namespace BetterBPMGDCLI.Models.LevelsSave.Ciphers.Factories
{
    public interface ILocalLevelCipherFactory
    {
        ILocalLevelCipher Decode(ILocalLevelCipher data);
        ILocalLevelCipher Decode(string data);
        ILocalLevelCipher Decode(byte[] data);
    }
}
