using System.IO.Compression;
using System.Text;

namespace BetterBPMGDCLI.Models
{
    public class LocalLevelsCipher
    {
        private byte[] localLevelsBytes;
        private string localLevelsString;

        public byte[] LocalLevelsBytes => localLevelsBytes;
        public string LocalLevelsString => localLevelsString;

        public LocalLevelsCipher(byte[] levelsSaveData)
        {
            localLevelsBytes = levelsSaveData;
            localLevelsString = Encoding.UTF8.GetString(levelsSaveData);
        }

        public LocalLevelsCipher(string levelsSaveData)
        {
            localLevelsString = levelsSaveData;
            localLevelsBytes = Encoding.UTF8.GetBytes(levelsSaveData);
        }

        public LocalLevelsCipher ApplyXOR(int key)
        {
            for (int i = 0; i < localLevelsBytes.Length; i++) localLevelsBytes[i] = (byte)(localLevelsBytes[i] ^ key);

            return new(localLevelsBytes);
        }

        public LocalLevelsCipher ApplyBase64(bool decode)
        {
            if (decode) return new(FromBase64(localLevelsString));

            return new(ToBase64(localLevelsBytes));
        }

        public LocalLevelsCipher ApplyGZIP(bool compress)
        {
            if (compress) return new(GZIPCompress(localLevelsBytes));

            return new(GZIPDecompress(localLevelsBytes));
        }

        private static byte[] FromBase64(string input)
        {
            var formatted = input.Replace('-', '+').Replace('_', '/').Replace("\0", string.Empty);
            int remaining = formatted.Length % 4;

            if (remaining > 0) formatted += new string('=', 4 - remaining);

            return Convert.FromBase64String(formatted);
        }

        private static string ToBase64(byte[] input) => Convert.ToBase64String(input);

        private static byte[] GZIPDecompress(byte[] input)
        {
            using MemoryStream uncompressedStream = new(input);
            using MemoryStream resultStream = new();
            using GZipStream zipStream = new(resultStream, CompressionMode.Compress);

            uncompressedStream.CopyTo(zipStream);

            zipStream.Close();

            return resultStream.ToArray();
        }

        private static byte[] GZIPCompress(byte[] input)
        {
            using MemoryStream compressedStream = new(input);
            using MemoryStream resultStream = new();
            using GZipStream zipStream = new(compressedStream, CompressionMode.Decompress);

            zipStream.CopyTo(resultStream);

            return resultStream.ToArray();
        }
    }
}
