using System.IO.Compression;
using System.Text;

namespace BetterBPMGDCLI.Models.LevelsSave.Ciphers
{
    public abstract class BaseLocalLevelCipher
    {
        protected string localLevelsString;
        protected byte[] localLevelsByteArray;

        public virtual string LocalLevelsString => localLevelsString;
        public virtual byte[] LocalLevelsByteArray => localLevelsByteArray;

        public BaseLocalLevelCipher(string localLevelsString)
        {
            this.localLevelsString = localLevelsString;
            localLevelsByteArray = Encoding.UTF8.GetBytes(localLevelsString);
        }

        public BaseLocalLevelCipher(byte[] localLevelsByteArray)
        {
            this.localLevelsByteArray = localLevelsByteArray;
            localLevelsString = Encoding.UTF8.GetString(localLevelsByteArray);
        }

        public string FromBase64UrlToBase64()
        {
            localLevelsString = localLevelsString.Replace('-', '+').Replace('_', '/').Replace("\0", string.Empty);

            int remaining = localLevelsString.Length % 4;

            if (remaining > 0) { localLevelsString += new string('=', 4 - remaining); }

            return localLevelsString;
        }

        public byte[] FromBase64ToByteArray() => Convert.FromBase64String(localLevelsString);

        public byte[] GZIPDecompress()
        {
            using var compressedstream = new MemoryStream(localLevelsByteArray);
            using var resultstream = new MemoryStream();
            using var zipstream = new GZipStream(compressedstream, CompressionMode.Decompress);

            zipstream.CopyTo(resultstream);

            return resultstream.ToArray();
        }
    }
}
