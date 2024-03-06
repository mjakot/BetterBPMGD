using BetterBPMGDCLI.Extensions;
using System.Xml.Linq;

namespace BetterBPMCLI.Tests.ExtensionsTests
{
    public class XElementExtensionTest
    {
        public const string MINIMALLOCALLEVELS = """<?xml version="1.0"?><plist version="1.0" gjver="2.0"><dict><k>LLM_01</k><d><k>_isArr</k><t/><k>k_0</k><d><k>kCEK</k><i>4</i><k>k18</k><i>1</i><k>k2</k><s>minimalLevel</s><k>k4</k><s>H4sIAAAAAAAAC6WTwQ3DMAwDF3IBUZLTBH1lhg7AAbJCh29k5pmgLfohYVM-Swa8PWNuYBqd8M6g905A5jJtJm_gRJgZ7wTRS2YaZ-IFDoT5dwj8j1hOEVWjA19BnHX-DPTTk-zr_xl5ykDUQKUx9MNA_XKgH19mugC1bUU0K-uySZZt16lh1_tQP3KtMNfqGcvY9KHijGDNoUphKlKVq8xV4cKlySBz3SiUixLKQlmozRQsBYtQljI1HLqhPkbZovaPvkXxo0Go3d0eby5QMLtKAwAA</s><k>k101</k><s>0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0</s><k>k13</k><t/><k>k21</k><i>2</i><k>k16</k><i>1</i><k>k80</k><i>62</i><k>k83</k><i>64</i><k>k50</k><i>38</i><k>kI1</k><r>135.998</r><k>kI2</k><r>87.6023</r><k>kI3</k><r>0.3</r><k>kI5</k><i>5</i><k>kI6</k><d><k>0</k><s>0</s><k>1</k><s>0</s><k>2</k><s>0</s><k>3</k><s>0</s><k>4</k><s>0</s><k>5</k><s>0</s><k>6</k><s>0</s><k>7</k><s>0</s><k>8</k><s>0</s><k>9</k><s>0</s><k>10</k><s>0</s><k>11</k><s>0</s><k>12</k><s>0</s><k>13</k><s>0</s></d></d></d><k>LLM_02</k><i>38</i><k>LLM_03</k><d><k>_isArr</k><t/></d></dict></plist>""";

        [Fact(Skip = "later")]
        public void FindAllLevelsByName_LevelName_FoundLevels()
        {
            const string levelName = "minimalLevel";

            XElement levels = XElement.Parse(MINIMALLOCALLEVELS);



            IEnumerable<BetterBPMGDCLI.Managers.LevelPreview?> foundLevels = levels.FindAllLevelsByName(levelName);



            Assert.True(foundLevels.Any());
            Assert.True(foundLevels.Count() == 1);
            Assert.Equal(levelName, foundLevels.ElementAt(0)!.Value.LevelName);
        }
    }
}
