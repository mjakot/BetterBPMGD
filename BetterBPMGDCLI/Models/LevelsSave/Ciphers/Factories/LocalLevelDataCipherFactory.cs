namespace BetterBPMGDCLI.Models.LevelsSave.Ciphers.Factories
{
    public class LocalLevelDataCipherFactory
    {
        public static LocalLevelDataCipher Decode(LocalLevelDataCipher data) => data.FromBase64UrlToBase64().FromBase64ToByteArray().GZIPDecompress();
    }
}
