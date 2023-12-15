using BetterBPMGDCLI.Models.LevelsSave.Ciphers;
using BetterBPMGDCLI.Models.LevelsSave.Ciphers.Factories;

namespace BetterBPMCLI.Tests.ModelsLevelsSaveCiphersFactoriesTests
{
    public class LocalLevelsCipherFactoryTest
    {
        [Fact]
        public void Decode_ValidLevelString_ReturnValidXML()
        {
            const string validMinimalLevelString = @"C?xBJJJJJJJJHg\Y99=HZIYMm3S?JZ^]NYFhF?|bBHA?Z8`c]ILeSCZRZ[Oyb9a_o{@_qM<<=j|aaxx?jc]&X}N:Li^<C9s<OFYicLe9e<jHyqz[98=O3Z_[fQJOBL~G:r9BqAcaQ<QsYXfjQFq>lgHgT:ZqXoE|`O_fY|l<dEdHOLHR=2X[hG[sBQ9e_2o>o_[;939[Tc8AxyCMSc&rMbG&2\i<@JM:ef:iSX:QSgeo^rs_l{?R~YOOF^EB:DhlmZqFsHgl9A&yTF[r}@9:glE3@R8qJn99;hjZcyH8By[CMI;hECIH>Mj>}YQ9SCa8_\8cgDm@Y{[c<@d^`=Fje?~rg\s^aY=gL\AA]laOaXX>o@Fl;gn~X}<QGCg_Em}|sAEX&f`ndohr<aESyg>O9C[X?Nl8TXJ|JOHQ`&f]}jj}=>m~aOd:\>zl^sq@mJE>|MeshRIJJJ";
            const string validMinimalLevelXML = @"<?xml version=""1.0""?><plist version=""1.0"" gjver=""2.0""><dict><k>LLM_01</k><d><k>_isArr</k><t/><k>k_0</k><d><k>kCEK</k><i>4</i><k>k2</k><s>minimalLevel</s><k>k5</k><s>username</s><k>k4</k><s>H4sIAAAAAAAACqWOwQ3DMAhFF6ISH2LHUU6ZIQP8AbJChq8NPSZqql54Asz7PnZvAk5KI6zQaaUQSFgihxNfYCVUlTNB9A3RqGzECYZC7ZkC_yuWS8V4kwePJMZxfyWCD9GoHvWLqNyKfvxRvRHJscFFB0qiJqZANnOOPmgDuy_RWdQ0xGLLw9xCExBdIaYuJt4TXHpaz8X6Bg8FpLgqAgAA</s></d></d></dict><k>LLM_02</k><i>35</i></plist>";

            LocalLevelsCipher localLevelsCipher = new(validMinimalLevelString);


            
            LocalLevelsCipher localLevelsCipherFactoryResult = LocalLevelsCipherFactory.Decode(localLevelsCipher);

            string actual = localLevelsCipherFactoryResult.DataString;



            Assert.Equal(validMinimalLevelXML, actual);
        }

        [Fact]
        public void Decode_EmptyString_ReturnsEmptyString()
        {
            string emptyEntry = string.Empty;
            string emptyResult = string.Empty;

            LocalLevelsCipher localLevelsCipher = new(emptyEntry);



            LocalLevelsCipher localLevelsCipherFactoryResult = LocalLevelsCipherFactory.Decode(localLevelsCipher);

            string actual = localLevelsCipherFactoryResult.DataString;



            Assert.Equal(emptyResult, actual);
        }
    }
}
