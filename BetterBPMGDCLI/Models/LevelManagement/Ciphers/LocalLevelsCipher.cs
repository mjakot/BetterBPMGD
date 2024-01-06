namespace BetterBPMGDCLI.Models.LevelsSave.Ciphers
{
    public class LocalLevelsCipher : BaseLocalLevelCipher
    {
        public const int XORDecryptionKey = 11;

        public LocalLevelsCipher(string localLevelsString) : base(localLevelsString) { }

        public LocalLevelsCipher(byte[] localLevelsByteArray) : base(localLevelsByteArray) { }

        private void XOR(int key)
        {
            for (int i = 0; i < dataString.Length; i++) dataByteArray[i] = (byte)(dataByteArray[i] ^ key);

            DataByteArray = dataByteArray;
        }

        public override string Decode()
        {
            string dataStringCopy = DataString;

            try
            {
                XOR(XORDecryptionKey);
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
