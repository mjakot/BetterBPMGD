using System.IO.Compression;

namespace BetterBPMGDCLI.Models.LevelsSave
{
    public class LocalLevelDataCipher : BaseLocalLevelCipher
    {
        public LocalLevelDataCipher(string localLevelsString) : base(localLevelsString) { }

        public LocalLevelDataCipher(byte[] localLevelsByteArray) : base(localLevelsByteArray) { }

        public LocalLevelDataCipher FromBase64UrlToBase64() => new(FromBase64UrlToBase64(localLevelsString));

        public LocalLevelDataCipher GZIPDecompress()
        {
            using var compressedstream = new MemoryStream(localLevelsByteArray);
            using var resultstream = new MemoryStream();
            using var zipstream = new GZipStream(compressedstream, CompressionMode.Decompress);

            zipstream.CopyTo(resultstream);

            return new(resultstream.ToArray());
        }

        public LocalLevelDataCipher FromBase64ToByteArray() => new(Convert.FromBase64String(localLevelsString));
    }
}
