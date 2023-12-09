using BetterBPMGDCLI.Utils;
using System.IO.Compression;
using System.Text;

namespace BetterBPMGDCLI.Models
{
    public class LocalLevelsCipher : Base64Conversion
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
            return new(FromBase64UrlToBase64(localLevelsString));
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
