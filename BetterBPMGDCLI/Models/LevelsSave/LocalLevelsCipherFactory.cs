namespace BetterBPMGDCLI.Models.LevelsSave
{
    public class LocalLevelsCipherFactory
    {
        public static LocalLevelsCipher Decode(LocalLevelsCipher data) => data.XOR(11).FromBase64UrlToBase64().FromBase64ToByteArray().GZIPDecompress();

        //Geometry dash actually encrypts xml files by itself so Encrypt() method is not really useful
    }
}
