using System.IO.Compression;
using System.Text;

namespace BetterBPMGDCLI.Models
{
    public class LocalLevelsCipher
    {
        string localLevelsString;
        byte[] localLevelsByteArray;

        public string LocalLevelsString => localLevelsString;
        public byte[] LocalLevelsByteArray => localLevelsByteArray;

        public LocalLevelsCipher(string localLevelsString)
        {
            this.localLevelsString = localLevelsString;
            localLevelsByteArray = Encoding.UTF8.GetBytes(localLevelsString);
        }

        public LocalLevelsCipher(byte[] localLevelsByteArray)
        {
            this.localLevelsByteArray = localLevelsByteArray;
            localLevelsString = Encoding.UTF8.GetString(localLevelsByteArray);
        }

        public LocalLevelsCipher XOR(int key)
        {
            for (int i = 0; i < localLevelsString.Length; i++) localLevelsByteArray[i] = (byte)(localLevelsByteArray[i] ^ key);

            return new(localLevelsByteArray);
        }

        public LocalLevelsCipher FromBase64UrlToBase64()
        {
            localLevelsString = localLevelsString.Replace('-', '+').Replace('_', '/').Replace("\0", string.Empty);

            int remaining = localLevelsString.Length % 4;

            if (remaining > 0) { localLevelsString += new string('=', 4 - remaining); }

            return new(localLevelsString);
        }

        public LocalLevelsCipher FromBase64ToByteArray()
        {
            localLevelsByteArray = Convert.FromBase64String(localLevelsString);

            return new(localLevelsByteArray);
        }

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
