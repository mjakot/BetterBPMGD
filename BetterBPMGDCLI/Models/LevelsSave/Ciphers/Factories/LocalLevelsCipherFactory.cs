namespace BetterBPMGDCLI.Models.LevelsSave.Ciphers.Factories
{
    public class LocalLevelsCipherFactory
    {
        public static LocalLevelsCipher Decode(LocalLevelsCipher data)
        {
            LocalLevelsCipher result = data.XOR(11)
                .FromBase64UrlToBase64()
                .FromBase64ToByteArray()
                .GZIPDecompress();

            return result;
        }

        //Geometry dash actually encrypts xml files by itself so there is no need for Encrypt()
    }
}
