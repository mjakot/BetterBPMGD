namespace BetterBPMGDCLI.Models
{
    public class LevelsSaveCipher
    {
        private byte[] levelsSaveData;

        public byte[] LevelsSaveData => levelsSaveData;

        public LevelsSaveCipher(byte[] levelsSaveData) => this.levelsSaveData = levelsSaveData;

        public LevelsSaveCipher XOR(int key) => throw new NotImplementedException();

        public LevelsSaveCipher Base64(bool decode) => throw new NotImplementedException();

        public LevelsSaveCipher GZIP(bool fold) => throw new NotImplementedException();
    }
}
