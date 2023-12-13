namespace BetterBPMGDCLI.Models.LevelsSave.Ciphers
{
    public class LocalLevelDataCipher : BaseLocalLevelCipher
    {
        public LocalLevelDataCipher(string localLevelsString) : base(localLevelsString) { }

        public LocalLevelDataCipher(byte[] localLevelsByteArray) : base(localLevelsByteArray) { }

        public new LocalLevelDataCipher FromBase64UrlToBase64() => new(base.FromBase64UrlToBase64());

        public new LocalLevelDataCipher GZIPDecompress() => new(base.GZIPDecompress());

        public new LocalLevelDataCipher FromBase64ToByteArray() => new(base.FromBase64ToByteArray());
    }
}
