using BetterBPMGDCLI.Models.LevelsSave;
using System.IO.Compression;

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

        public LocalLevelsCipher FromBase64UrlToBase64() => new(FromBase64UrlToBase64(localLevelsString));

        public LocalLevelsCipher FromBase64ToByteArray() => new(Convert.FromBase64String(localLevelsString));

        public LocalLevelsCipher GZIPDecompress()
        {
            using var compressedstream = new MemoryStream(localLevelsByteArray);
            using var resultstream = new MemoryStream();
            using var zipstream = new GZipStream(compressedstream, CompressionMode.Decompress);

            zipstream.CopyTo(resultstream);

            return new(resultstream.ToArray());
        }
    }
}
