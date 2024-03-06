using BetterBPMGDCLI.Extensions;
using BetterBPMGDCLI.Models.Settings;

namespace BetterBPMCLI.Tests.Context
{
    public class PathSettingsMock : SettingsBase, IPathSettings
    {
        private bool initialized = false;

        public string AppDataFolderPath { get => "C:\\BetterBPMGDTestAppData\\"; set => throw new NotImplementedException(); }
        public string BetterBPMGDFolderPath { get => Path.Combine(AppDataFolderPath, "BetterBPMGDTest\\"); set => throw new NotImplementedException(); }
        public string GeometryDashSavesFolderPath { get => Path.Combine(AppDataFolderPath, "GeometryDashTest\\"); set => throw new NotImplementedException(); }
        public string TimingProjectsFolderPath { get => Path.Combine(BetterBPMGDFolderPath, "ProjectsTest\\"); set => throw new NotImplementedException(); }
        public string TimingListPath { get => "TimingsTest.txt"; set => throw new NotImplementedException(); }
        public string SongListPath { get => "SongsTest.txt"; set => throw new NotImplementedException(); }
        public string GeometryDashLevelsSavePath { get => Path.Combine(GeometryDashSavesFolderPath, "LocalLevelTest.dat"); set => throw new NotImplementedException(); }
        public string SettingsFolderPath { get => Path.Combine(BetterBPMGDFolderPath, "settings\\"); set => throw new NotImplementedException(); }
        public string CurrentProjectSaveFilePath { get => Path.Combine(BetterBPMGDFolderPath, "currentproj.txt"); set => throw new NotImplementedException(); }
        public string BackupFolderPath { get => Path.Combine(GeometryDashSavesFolderPath, "BackupsTest\\"); set => throw new NotImplementedException(); }
        public string MinimalLevelPath { get => Path.Combine(BetterBPMGDFolderPath, "MinimalLevelTest.xml"); set => throw new NotImplementedException(); }

        public PathSettingsMock() => InitializeFileSystem();

        private void InitializeFileSystem()
        {
            if (initialized) return;

            Directory.Delete(AppDataFolderPath, true);
            
            Directory.CreateDirectory(AppDataFolderPath);
            Directory.CreateDirectory(BetterBPMGDFolderPath);
            Directory.CreateDirectory(GeometryDashSavesFolderPath);
            Directory.CreateDirectory(TimingProjectsFolderPath);
            Directory.CreateDirectory(BackupFolderPath);
            Directory.CreateDirectory(SettingsFolderPath);

            string minimalLevel = """<d><k>kCEK</k><i>4</i><k>k18</k><i>1</i><k>k2</k><s>minimalLevel</s><k>k4</k><s>kS38,1_40_2_125_3_255_11_255_12_255_13_255_4_-1_6_1000_7_1_15_1_18_0_8_1|1_0_2_102_3_255_11_255_12_255_13_255_4_-1_6_1001_7_1_15_1_18_0_8_1|1_0_2_102_3_255_11_255_12_255_13_255_4_-1_6_1009_7_1_15_1_18_0_8_1|1_255_2_255_3_255_11_255_12_255_13_255_4_-1_6_1002_5_1_7_1_15_1_18_0_8_1|1_40_2_125_3_255_11_255_12_255_13_255_4_-1_6_1013_7_1_15_1_18_0_8_1|1_40_2_125_3_255_11_255_12_255_13_255_4_-1_6_1014_7_1_15_1_18_0_8_1|1_135_2_135_3_135_11_255_12_255_13_255_4_-1_6_1005_5_1_7_1_15_1_18_0_8_1|1_255_2_255_3_255_11_255_12_255_13_255_4_-1_6_1006_5_1_7_1_15_1_18_0_8_1|,kA13,0,kA15,0,kA16,0,kA14,,kA6,1,kA7,1,kA25,0,kA17,1,kA18,0,kS39,0,kA2,0,kA3,0,kA8,0,kA4,0,kA9,0,kA10,0,kA22,0,kA23,0,kA24,0,kA27,1,kA40,1,kA41,1,kA42,1,kA28,0,kA29,0,kA31,1,kA32,1,kA36,0,kA43,0,kA44,0,kA33,1,kA34,1,kA35,0,kA37,1,kA38,1,kA39,1,kA19,0,kA26,0,kA20,0,kA21,0,kA11,0;</s><k>k101</k><s>0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0</s><k>k13</k><t/><k>k21</k><i>2</i><k>k16</k><i>1</i><k>k80</k><i>62</i><k>k83</k><i>64</i><k>k50</k><i>38</i><k>kI1</k><r>135.998</r><k>kI2</k><r>87.6023</r><k>kI3</k><r>0.3</r><k>kI5</k><i>5</i><k>kI6</k><d><k>0</k><s>0</s><k>1</k><s>0</s><k>2</k><s>0</s><k>3</k><s>0</s><k>4</k><s>0</s><k>5</k><s>0</s><k>6</k><s>0</s><k>7</k><s>0</s><k>8</k><s>0</s><k>9</k><s>0</s><k>10</k><s>0</s><k>11</k><s>0</s><k>12</k><s>0</s><k>13</k><s>0</s></d></d>""";
            string minimalLocalLevels = """<?xml version="1.0"?><plist version="1.0" gjver="2.0"><dict><k>LLM_01</k><d><k>_isArr</k><t/><k>k_0</k><d><k>kCEK</k><i>4</i><k>k18</k><i>1</i><k>k2</k><s>minimalLevel</s><k>k4</k><s>H4sIAAAAAAAAC6WTwQ3DMAwDF3IBUZLTBH1lhg7AAbJCh29k5pmgLfohYVM-Swa8PWNuYBqd8M6g905A5jJtJm_gRJgZ7wTRS2YaZ-IFDoT5dwj8j1hOEVWjA19BnHX-DPTTk-zr_xl5ykDUQKUx9MNA_XKgH19mugC1bUU0K-uySZZt16lh1_tQP3KtMNfqGcvY9KHijGDNoUphKlKVq8xV4cKlySBz3SiUixLKQlmozRQsBYtQljI1HLqhPkbZovaPvkXxo0Go3d0eby5QMLtKAwAA</s><k>k101</k><s>0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0</s><k>k13</k><t/><k>k21</k><i>2</i><k>k16</k><i>1</i><k>k80</k><i>62</i><k>k83</k><i>64</i><k>k50</k><i>38</i><k>kI1</k><r>135.998</r><k>kI2</k><r>87.6023</r><k>kI3</k><r>0.3</r><k>kI5</k><i>5</i><k>kI6</k><d><k>0</k><s>0</s><k>1</k><s>0</s><k>2</k><s>0</s><k>3</k><s>0</s><k>4</k><s>0</s><k>5</k><s>0</s><k>6</k><s>0</s><k>7</k><s>0</s><k>8</k><s>0</s><k>9</k><s>0</s><k>10</k><s>0</s><k>11</k><s>0</s><k>12</k><s>0</s><k>13</k><s>0</s></d></d></d><k>LLM_02</k><i>38</i><k>LLM_03</k><d><k>_isArr</k><t/></d></dict></plist>""";

            File.WriteAllText(MinimalLevelPath, minimalLevel);
            File.WriteAllText(GeometryDashLevelsSavePath, minimalLocalLevels);
            File.Copy(".\\AMONGUS.mp3", Path.Combine(GeometryDashSavesFolderPath, "-100.mp3"));

            initialized = true;
        }

        public string GetSongListPath(string projectName) => Path.Combine(GetTimingProjectFolderPath(projectName), SongListPath);

        public string GetSongPathById(string projectName, int id)
        {
            string path = GetTimingProjectFolderPath(projectName);
            string name = $"{id}.mp3";

            return Path.Combine(path, name);
        }

        public string GetTimingListPath(string projectName) => Path.Combine(GetTimingProjectFolderPath(projectName), TimingListPath);

        public string GetTimingProjectFolderPath(string projectName) => Path.Combine(TimingProjectsFolderPath, $"{projectName}\\");

        public override string ToString() => this.Serialize(false);
    }
}
