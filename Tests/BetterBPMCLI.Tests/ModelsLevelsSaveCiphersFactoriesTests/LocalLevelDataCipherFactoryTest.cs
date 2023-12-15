using BetterBPMGDCLI.Models.LevelsSave.Ciphers;
using BetterBPMGDCLI.Models.LevelsSave.Ciphers.Factories;

namespace BetterBPMCLI.Tests.ModelsLevelsSaveCiphersFactoriesTests
{
    public class LocalLevelDataCipherFactoryTest
    {
        [Fact]
        public void Decode_ValidLevelDataStringEncoded_ReturnsValidLevelDataStringDecoded()
        {
            const string validMinimalLevelDataStringEncoded = @"H4sIAAAAAAAACqWOwQ3DMAhFF6ISH2LHUU6ZIQP8AbJChq8NPSZqql54Asz7PnZvAk5KI6zQaaUQSFgihxNfYCVUlTNB9A3RqGzECYZC7ZkC_yuWS8V4kwePJMZxfyWCD9GoHvWLqNyKfvxRvRHJscFFB0qiJqZANnOOPmgDuy_RWdQ0xGLLw9xCExBdIaYuJt4TXHpaz8X6Bg8FpLgqAgAA";
            const string validMinimalLevelDataStringDecoded = @"kS38,1_40_2_125_3_255_11_255_12_255_13_255_4_-1_6_1000_7_1_15_1_18_0_8_1|1_0_2_102_3_255_11_255_12_255_13_255_4_-1_6_1001_7_1_15_1_18_0_8_1|1_0_2_102_3_255_11_255_12_255_13_255_4_-1_6_1009_7_1_15_1_18_0_8_1|1_255_2_255_3_255_11_255_12_255_13_255_4_-1_6_1002_5_1_7_1_15_1_18_0_8_1|1_135_2_135_3_135_11_255_12_255_13_255_4_-1_6_1005_5_1_7_1_15_1_18_0_8_1|1_255_2_255_3_255_11_255_12_255_13_255_4_-1_6_1006_5_1_7_1_15_1_18_0_8_1|,kA13,0,kA15,0,kA16,0,kA14,0,kA6,0,kA7,0,kA17,0,kA18,0,kS39,0,kA2,0,kA3,0,kA8,0,kA4,0,kA9,0,kA10,0,kA11,0;1,203,2,316,3,15,13,1;";

            LocalLevelDataCipher localLevelDataCipher = new(validMinimalLevelDataStringEncoded);



            LocalLevelDataCipher localLevelDataCipherFactoryResult = LocalLevelDataCipherFactory.Decode(localLevelDataCipher);

            string actual = localLevelDataCipherFactoryResult.DataString;



            Assert.Equal(validMinimalLevelDataStringDecoded, actual);
        }

        [Fact]
        public void Decode_EmptyString_ReturnEmptyString()
        {
            string emptyEntry = string.Empty;
            string emptyResult = string.Empty;

            LocalLevelDataCipher localLevelDataCipher = new(emptyEntry);



            LocalLevelDataCipher localLevelDataCipherFactoryResult = LocalLevelDataCipherFactory.Decode(localLevelDataCipher);

            string actual = localLevelDataCipherFactoryResult.DataString;



            Assert.Equal(emptyResult, actual);
        }
    }
}
