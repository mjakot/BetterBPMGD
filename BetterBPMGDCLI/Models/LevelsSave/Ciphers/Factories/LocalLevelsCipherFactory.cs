namespace BetterBPMGDCLI.Models.LevelsSave.Ciphers.Factories
{
    public class LocalLevelsCipherFactory : ILocalLevelCipherFactory
    {
        private static LocalLevelsCipher DecodeLocalLevelsCipher(LocalLevelsCipher data)
        {
            try
            {
                return data.XOR(11)
                            .FromBase64UrlToBase64()
                            .FromBase64ToByteArray()
                            .GZIPDecompress();
            }
            catch (Exception)
            {
                return data;
            }
        }

        public ILocalLevelCipher Decode(ILocalLevelCipher data) => DecodeLocalLevelsCipher((LocalLevelsCipher)data);

        public ILocalLevelCipher Decode(string data)
        {
            LocalLevelsCipher localLevelCipher = new(data);

            return DecodeLocalLevelsCipher(localLevelCipher);
        }

        public ILocalLevelCipher Decode(byte[] data)
        {
            LocalLevelsCipher localLevelsCipher = new(data);

            return DecodeLocalLevelsCipher(localLevelsCipher);
        }
    }
}
