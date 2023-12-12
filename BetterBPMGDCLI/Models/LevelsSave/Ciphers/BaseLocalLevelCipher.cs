using System.IO.Compression;
using System.Text;

namespace BetterBPMGDCLI.Models.LevelsSave.Ciphers
{
    public abstract class BaseLocalLevelCipher
    {
        protected string dataString;
        protected byte[] dataByteArray;

        public virtual string DataString => dataString;
        public virtual byte[] DataByteArray => dataByteArray;

        public BaseLocalLevelCipher(string localLevelsString)
        {
            this.dataString = localLevelsString;
            dataByteArray = Encoding.UTF8.GetBytes(localLevelsString);
        }

        public BaseLocalLevelCipher(byte[] localLevelsByteArray)
        {
            this.dataByteArray = localLevelsByteArray;
            dataString = Encoding.UTF8.GetString(localLevelsByteArray);
        }

        public string FromBase64UrlToBase64()
        {
            dataString = dataString.Replace('-', '+').Replace('_', '/').Replace("\0", string.Empty);

            int remaining = dataString.Length % 4;

            if (remaining > 0) { dataString += new string('=', 4 - remaining); }

            return dataString;
        }

        public byte[] FromBase64ToByteArray() => Convert.FromBase64String(dataString);

        public byte[] GZIPDecompress()
        {
            using var compressedstream = new MemoryStream(dataByteArray);
            using var resultstream = new MemoryStream();
            using var zipstream = new GZipStream(compressedstream, CompressionMode.Decompress);

            zipstream.CopyTo(resultstream);

            return resultstream.ToArray();
        }
    }
}
