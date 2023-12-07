namespace BetterBPMGDCLI.Models.LevelsSave
{
    public class LevelsSaveCipherFactory
    {
        public LevelsSaveCipher Decode(LevelsSaveCipher data) => data.ApplyXOR(11).ApplyBase64(true).ZLIB(false);

        public LevelsSaveCipher Encode(LevelsSaveCipher data) => throw new NotImplementedException();
    }
}
