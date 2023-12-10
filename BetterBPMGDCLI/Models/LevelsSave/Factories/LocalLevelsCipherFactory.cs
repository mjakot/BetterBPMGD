using BetterBPMGDCLI.Models.LevelsSave.Ciphers;

namespace BetterBPMGDCLI.Models.LevelsSave.Factories
{
    public class LocalLevelsCipherFactory
    {
        //TODO: move cache saving in different place
        public static LocalLevelsCipher Decode(LocalLevelsCipher data)
        {
            LocalLevelsCipher result = data.XOR(11)
                .FromBase64UrlToBase64()
                .FromBase64ToByteArray()
                .GZIPDecompress();

            Cache.Cache.SaveCache(result.LocalLevelsString);

            return result;
        }

        //Geometry dash actually encrypts xml files by itself so there is no need for Encrypt()
    }
}
