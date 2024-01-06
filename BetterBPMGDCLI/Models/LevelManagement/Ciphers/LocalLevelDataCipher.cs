namespace BetterBPMGDCLI.Models.LevelsSave.Ciphers
{
    public class LocalLevelDataCipher : BaseLocalLevelCipher
    {
        public LocalLevelDataCipher(string localLevelsString) : base(localLevelsString) { }

        public LocalLevelDataCipher(byte[] localLevelsByteArray) : base(localLevelsByteArray) { }

        public override string Decode()
        {
            string dataStringCopy = DataString;

            try
            {
                FromBase64UrlToBase64();
                FromBase64ToByteArray();
                GZIPDecompress();

                return DataString;
            }
            catch (Exception)
            {
                return dataStringCopy;
            }
        }
    }
}
