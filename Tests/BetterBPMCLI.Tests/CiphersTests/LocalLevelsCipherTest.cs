using BetterBPMGDCLI.Models.Ciphers;

namespace BetterBPMCLI.Tests.CiphersTests
{
    public class LocalLevelsCipherTest
    {
        const string MINIMALLOCALLEVELS = """C?xBJJJJJJJJHd9_9S@bZIXLSrSg2Xl;HNB]=YYB?lBR^SOcceBGEBxdd@I[[?Qfr_cqF]I^3STo>T_{x|c}nYb3SJ2slzGaj|;rERiMN?IXBT=R}a[mYyb8y3Z9L[ob`^m@bzf`;HlmJm=M}i@ICa~EJ{3Z:3f9s\Tm=<^blN~|@IHlX?`dH@^J]BRBbD@E|N=~M=HJZb@oj=>oz|f?qN3~fqXr[_j]`_FTfOC`ff{YyXNJX~;s[M<ia}^yq[eNACTRyh2^Ayq<FEE::DGf}{}Dh;:~MAYfX3h_dDi\h9ozsnQxqf:C{a^hmhfZ|&3qa[DI&}b&\elc?=_chn\{Rman9qeJS[qQ]ESqAqSAz@2^{|c?FDG;|oi;rX]2~^9=|^xBNG<MXm;`zz_i<Dl2::qXO>J8`X\XnSH]ZMfh~S8Y8XeHiX8o=a`r^z?dncEM2{bmXD^Oi|XL=fo&gxy~f=f]8&]Y&Zld}m`RSaoN:EM_N_sX{SdHsFJxgmTTS\c}_[JgGRH?A^S_G9~\ZhGa@HiG9Adr^g>z{oMhc^iRnZ|IqSY?TxMaqCN_sAOyo]bXdf~D}hjZ<OXF@o;r]n9=_frr`M>~qde{j==yoG?lNQSC]o{mMba3]LE<a:{8E=E>{Ta&X}J>|aIh?cgmX{J[D>Qmn]NRdxmbX?dE}}SeLGqRzjAR}ici2{eTShRIJJJ""";
        const string MINIMALLOCALLEVELSDECRYPTED = """<?xml version="1.0"?><plist version="1.0" gjver="2.0"><dict><k>LLM_01</k><d><k>_isArr</k><t/><k>k_0</k><d><k>kCEK</k><i>4</i><k>k18</k><i>1</i><k>k2</k><s>minimalLevel</s><k>k4</k><s>H4sIAAAAAAAAC6WTwQ3DMAwDF3IBUZLTBH1lhg7AAbJCh29k5pmgLfohYVM-Swa8PWNuYBqd8M6g905A5jJtJm_gRJgZ7wTRS2YaZ-IFDoT5dwj8j1hOEVWjA19BnHX-DPTTk-zr_xl5ykDUQKUx9MNA_XKgH19mugC1bUU0K-uySZZt16lh1_tQP3KtMNfqGcvY9KHijGDNoUphKlKVq8xV4cKlySBz3SiUixLKQlmozRQsBYtQljI1HLqhPkbZovaPvkXxo0Go3d0eby5QMLtKAwAA</s><k>k101</k><s>0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0</s><k>k13</k><t/><k>k21</k><i>2</i><k>k16</k><i>1</i><k>k80</k><i>62</i><k>k83</k><i>64</i><k>k50</k><i>38</i><k>kI1</k><r>135.998</r><k>kI2</k><r>87.6023</r><k>kI3</k><r>0.3</r><k>kI5</k><i>5</i><k>kI6</k><d><k>0</k><s>0</s><k>1</k><s>0</s><k>2</k><s>0</s><k>3</k><s>0</s><k>4</k><s>0</s><k>5</k><s>0</s><k>6</k><s>0</s><k>7</k><s>0</s><k>8</k><s>0</s><k>9</k><s>0</s><k>10</k><s>0</s><k>11</k><s>0</s><k>12</k><s>0</s><k>13</k><s>0</s></d></d></d><k>LLM_02</k><i>38</i><k>LLM_03</k><d><k>_isArr</k><t/></d></dict></plist>""";

        [Fact]
        public void Decode_MinimalLevel_DecodedMinimalLevel()
        {
            LocalLevelsCipher cipher = new(MINIMALLOCALLEVELS);



            string actual = cipher.Decode();



            Assert.Equal(MINIMALLOCALLEVELSDECRYPTED, actual);
        }
    }
}
