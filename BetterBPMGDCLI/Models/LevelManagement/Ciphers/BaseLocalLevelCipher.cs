using System.IO.Compression;
using System.Text;

namespace BetterBPMGDCLI.Models.LevelsSave.Ciphers
{
    public abstract class BaseLocalLevelCipher : ILocalLevelCipher
    {
        protected string dataString;
        protected byte[] dataByteArray;

        public virtual string DataString
        {
            get => dataString;
            set
            {
                dataString = value;
                dataByteArray = Encoding.UTF8.GetBytes(value);
            }
        }

        public virtual byte[] DataByteArray
        {
            get => dataByteArray;
            set
            {
                dataByteArray = value;
                dataString = Encoding.UTF8.GetString(DataByteArray);
            }
        }

        public BaseLocalLevelCipher(string localLevelsString)
        {
            dataString = localLevelsString;
            dataByteArray = Encoding.UTF8.GetBytes(localLevelsString);
        }

        public BaseLocalLevelCipher(byte[] localLevelsByteArray)
        {
            dataByteArray = localLevelsByteArray;
            dataString = Encoding.UTF8.GetString(localLevelsByteArray);
        }

        protected void FromBase64UrlToBase64()
        {
            DataString = dataString.Replace('-', '+').Replace('_', '/').Replace("\0", string.Empty);

            int remaining = DataString.Length % 4;

            if (remaining > 0) { DataString += new string('=', 4 - remaining); }
        }

        protected void FromBase64ToByteArray() => DataByteArray = Convert.FromBase64String(dataString);

        protected void GZIPDecompress()
        {
            using var compressedstream = new MemoryStream(dataByteArray);
            using var resultstream = new MemoryStream();
            using var zipstream = new GZipStream(compressedstream, CompressionMode.Decompress);

            zipstream.CopyTo(resultstream);

            DataByteArray = resultstream.ToArray();
        }

        public abstract string Decode();
    }
}
