namespace BetterBPMGDCLI.Models.LevelsSave
{
    public class LevelsSaveCipherFactory
    {
        public LevelsSaveCipher Decode(LevelsSaveCipher data) => data.XOR(11).Base64(true).ZLIB(false);

        public LevelsSaveCipher Encode(LevelsSaveCipher data) => throw new NotImplementedException();
    }
}
