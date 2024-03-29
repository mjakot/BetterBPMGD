﻿using BetterBPMGDCLI.Utils;

namespace BetterBPMGDCLI.Models.Ciphers
{
    public class LocalLevelsCipher : BaseLocalLevelCipher
    {
        public LocalLevelsCipher(string localLevelsString) : base(localLevelsString) { }

        public LocalLevelsCipher(byte[] localLevelsByteArray) : base(localLevelsByteArray) { }
        
        public override string Decode()
        {
            string dataStringCopy = DataString;

            try
            {
                XOR(Constants.XORDecryptionKey);
                FromBase64UrlToBase64();
                FromBase64ToByteArray();
                GZIPDecompress();

                return DataString;
            }
            catch (Exception)
            {
                return dataStringCopy;
            }
        }

        private void XOR(int key)
        {
            for (int i = 0; i < dataString.Length; i++)
                dataByteArray[i] = (byte)(dataByteArray[i] ^ key);

            DataByteArray = dataByteArray;
        }
    }
}
