namespace BetterBPMGDCLI.Models.LevelsSave.Ciphers.Factories
{
    public class LocalLevelDataCipherFactory : ILocalLevelCipherFactory
    {
        private static LocalLevelDataCipher DecodeLocalLevelDataCipher(LocalLevelDataCipher data)
        {
            try
            {
                return data.FromBase64UrlToBase64()
                            .FromBase64ToByteArray()
                            .GZIPDecompress();
            }
            catch (Exception)
            {
                return data;
            }
        }

        public ILocalLevelCipher Decode(ILocalLevelCipher data) => DecodeLocalLevelDataCipher((LocalLevelDataCipher)data);

        public ILocalLevelCipher Decode(string data)
        {
            LocalLevelDataCipher localLevelDataCipher = new(data);

            return DecodeLocalLevelDataCipher(localLevelDataCipher);
        }

        public ILocalLevelCipher Decode(byte[] data)
        {
            LocalLevelDataCipher localLevelDataCipher = new(data);

            return DecodeLocalLevelDataCipher(localLevelDataCipher);
        }
    }
}
