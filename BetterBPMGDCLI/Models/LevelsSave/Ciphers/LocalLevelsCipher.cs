namespace BetterBPMGDCLI.Models.LevelsSave.Ciphers
{
    public class LocalLevelsCipher : BaseLocalLevelCipher
    {
        public LocalLevelsCipher(string localLevelsString) : base(localLevelsString) { }

        public LocalLevelsCipher(byte[] localLevelsByteArray) : base(localLevelsByteArray) { }

        public LocalLevelsCipher XOR(int key)
        {
            for (int i = 0; i < dataString.Length; i++) dataByteArray[i] = (byte)(dataByteArray[i] ^ key);

            return new(dataByteArray);
        }

        public new LocalLevelsCipher FromBase64UrlToBase64() => new(base.FromBase64UrlToBase64());

        public new LocalLevelsCipher FromBase64ToByteArray() => new(base.FromBase64ToByteArray());

        public new LocalLevelsCipher GZIPDecompress() => new(base.GZIPDecompress());
    }
}
