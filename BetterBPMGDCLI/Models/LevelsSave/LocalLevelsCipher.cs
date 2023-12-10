using BetterBPMGDCLI.Models.LevelsSave;

namespace BetterBPMGDCLI.Models
{
    public class LocalLevelsCipher : BaseLocalLevelCipher
    {
        public LocalLevelsCipher(string localLevelsString) : base(localLevelsString) { }

        public LocalLevelsCipher(byte[] localLevelsByteArray) : base(localLevelsByteArray) { }

        public LocalLevelsCipher XOR(int key)
        {
            for (int i = 0; i < localLevelsString.Length; i++) localLevelsByteArray[i] = (byte)(localLevelsByteArray[i] ^ key);

            return new(localLevelsByteArray);
        }

        public new LocalLevelsCipher FromBase64UrlToBase64() => new(base.FromBase64UrlToBase64());

        public new LocalLevelsCipher FromBase64ToByteArray() => new(base.FromBase64ToByteArray());

        public new LocalLevelsCipher GZIPDecompress() => new(base.GZIPDecompress());
    }
}
