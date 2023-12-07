namespace BetterBPMGDCLI.Models
{
    public class LevelsSaveCipher
    {
        private byte[] levelsSaveData;

        public byte[] LevelsSaveData => levelsSaveData;

        public LevelsSaveCipher(byte[] levelsSaveData) => this.levelsSaveData = levelsSaveData;

        public LevelsSaveCipher ApplyXOR(int key)
        {
            for (int i = 0; i < levelsSaveData.Length; i++) levelsSaveData[i] = (byte)(levelsSaveData[i] ^ key);

            return new(levelsSaveData);
        }

        public LevelsSaveCipher ApplyBase64(bool decode) => throw new NotImplementedException();

        public LevelsSaveCipher ApplyGZIP(bool fold) => throw new NotImplementedException();
    }
}
