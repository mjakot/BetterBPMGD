namespace BetterBPMGDCLI.Models.LevelsSave
{
    public class LocalLevelsCipherFactory
    {
        public static LocalLevelsCipher Decode(LocalLevelsCipher data) => data.ApplyXOR(11).ApplyBase64(true).ApplyGZIP(false);

        //Geometry dash actually encrypts xml files by itself, so this is not really useful
        public static LocalLevelsCipher Encode(LocalLevelsCipher data) => data.ApplyGZIP(true).ApplyBase64(false).ApplyXOR(11);
    }
}
