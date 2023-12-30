using BetterBPMGDCLI.Models.Settings.Interfaces;
using System.Text;

namespace BetterBPMCLI.Tests.ModelsFileManagementTests
{
    public class FileManagerFixture : IDisposable
    {
        private static int counter = 0;

        public const string MinimalLevelsDecrypted = """<?xml version="1.0"?><plist version="1.0" gjver="2.0"><dict><k>LLM_01</k><d><k>_isArr</k><t/><k>k_0</k><d><k>kCEK</k><i>4</i><k>k18</k><i>1</i><k>k2</k><s>minimalLevel</s><k>k4</k><s>H4sIAAAAAAAAC6WTwQ3DMAwDF3IBUZLTBH1lhg7AAbJCh29k5pmgLfohYVM-Swa8PWNuYBqd8M6g905A5jJtJm_gRJgZ7wTRS2YaZ-IFDoT5dwj8j1hOEVWjA19BnHX-DPTTk-zr_xl5ykDUQKUx9MNA_XKgH19mugC1bUU0K-uySZZt16lh1_tQP3KtMNfqGcvY9KHijGDNoUphKlKVq8xV4cKlySBz3SiUixLKQlmozRQsBYtQljI1HLqhPkbZovaPvkXxo0Go3d0eby5QMLtKAwAA</s><k>k101</k><s>0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0</s><k>k13</k><t/><k>k21</k><i>2</i><k>k16</k><i>1</i><k>k80</k><i>62</i><k>k83</k><i>64</i><k>k50</k><i>38</i><k>kI1</k><r>135.998</r><k>kI2</k><r>87.6023</r><k>kI3</k><r>0.3</r><k>kI5</k><i>5</i><k>kI6</k><d><k>0</k><s>0</s><k>1</k><s>0</s><k>2</k><s>0</s><k>3</k><s>0</s><k>4</k><s>0</s><k>5</k><s>0</s><k>6</k><s>0</s><k>7</k><s>0</s><k>8</k><s>0</s><k>9</k><s>0</s><k>10</k><s>0</s><k>11</k><s>0</s><k>12</k><s>0</s><k>13</k><s>0</s></d></d></d><k>LLM_02</k><i>38</i><k>LLM_03</k><d><k>_isArr</k><t/></d></dict></plist>""";
        public const string TestDirectory = "c:\\BetterBPMTest\\";

        public FileManagerFixture()
        {
            if (Directory.Exists(TestDirectory)) Directory.Delete(TestDirectory, true);

            Directory.CreateDirectory(TestDirectory);
        }

        public void Dispose() { }

        public IFileManagerSettings CreateEnvironment()
        {            
            IFileManagerSettings settings = new TestFileManagerSettings(Path.Combine(TestDirectory, $"Test{counter++}"));

            Directory.CreateDirectory(settings.AppDataFolderPath);
            Directory.CreateDirectory(settings.BetterBPMGDAppDataFolderPath);
            Directory.CreateDirectory(settings.GDFolderPath);
            Directory.CreateDirectory(settings.BetterBPMGDTemporaryFolderPath);
            Directory.CreateDirectory(settings.BetterBPMGDLevelsSavesCopiesFolderPath);
            Directory.CreateDirectory(settings.BetterBPMGDCurrentLevelFolderPath);
            Directory.CreateDirectory(settings.ProjectsFolderPath);
            Directory.CreateDirectory(settings.BackupFolderPath);

            using (FileStream fs = File.Create(settings.GdLevelsSavePath))
            {
                string minimalLevels = """C?xBJJJJJJJJHd9_9S@bZIXLSrSg2Xl;HNB]=YYB?lBR^SOcceBGEBxdd@I[[?Qfr_cqF]I^3STo>T_{x|c}nYb3SJ2slzGaj|;rERiMN?IXBT=R}a[mYyb8y3Z9L[ob`^m@bzf`;HlmJm=M}i@ICa~EJ{3Z:3f9s\Tm=<^blN~|@IHlX?`dH@^J]BRBbD@E|N=~M=HJZb@oj=>oz|f?qN3~fqXr[_j]`_FTfOC`ff{YyXNJX~;s[M<ia}^yq[eNACTRyh2^Ayq<FEE::DGf}{}Dh;:~MAYfX3h_dDi\h9ozsnQxqf:C{a^hmhfZ|&3qa[DI&}b&\elc?=_chn\{Rman9qeJS[qQ]ESqAqSAz@2^{|c?FDG;|oi;rX]2~^9=|^xBNG<MXm;`zz_i<Dl2::qXO>J8`X\XnSH]ZMfh~S8Y8XeHiX8o=a`r^z?dncEM2{bmXD^Oi|XL=fo&gxy~f=f]8&]Y&Zld}m`RSaoN:EM_N_sX{SdHsFJxgmTTS\c}_[JgGRH?A^S_G9~\ZhGa@HiG9Adr^g>z{oMhc^iRnZ|IqSY?TxMaqCN_sAOyo]bXdf~D}hjZ<OXF@o;r]n9=_frr`M>~qde{j==yoG?lNQSC]o{mMba3]LE<a:{8E=E>{Ta&X}J>|aIh?cgmX{J[D>Qmn]NRdxmbX?dE}}SeLGqRzjAR}ici2{eTShRIJJJ""";
                byte[] minimalLevelsBytes = Encoding.UTF8.GetBytes(minimalLevels);

                fs.Write(minimalLevelsBytes, 0, minimalLevelsBytes.Length);
            }

            using (FileStream fs = File.Create(settings.MinimalLevelPath))
            {
                string minimalLevel = """<d><k>kCEK</k><i>4</i><k>k18</k><i>1</i><k>k2</k><s>minimalLevel</s><k>k4</k><s>H4sIAAAAAAAAC6WTwQ3DMAwDF3IBUZLTBH1lhg7AAbJCh29k5pmgLfohYVM-Swa8PWNuYBqd8M6g905A5jJtJm_gRJgZ7wTRS2YaZ-IFDoT5dwj8j1hOEVWjA19BnHX-DPTTk-zr_xl5ykDUQKUx9MNA_XKgH19mugC1bUU0K-uySZZt16lh1_tQP3KtMNfqGcvY9KHijGDNoUphKlKVq8xV4cKlySBz3SiUixLKQlmozRQsBYtQljI1HLqhPkbZovaPvkXxo0Go3d0eby5QMLtKAwAA</s><k>k101</k><s>0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0</s><k>k13</k><t/><k>k21</k><i>2</i><k>k16</k><i>1</i><k>k80</k><i>62</i><k>k83</k><i>64</i><k>k50</k><i>38</i><k>kI1</k><r>135.998</r><k>kI2</k><r>87.6023</r><k>kI3</k><r>0.3</r><k>kI5</k><i>5</i><k>kI6</k><d><k>0</k><s>0</s><k>1</k><s>0</s><k>2</k><s>0</s><k>3</k><s>0</s><k>4</k><s>0</s><k>5</k><s>0</s><k>6</k><s>0</s><k>7</k><s>0</s><k>8</k><s>0</s><k>9</k><s>0</s><k>10</k><s>0</s><k>11</k><s>0</s><k>12</k><s>0</s><k>13</k><s>0</s></d></d>""";
                byte[] minimalLevelBytes = Encoding.UTF8.GetBytes(minimalLevel);

                fs.Write(minimalLevelBytes, 0, minimalLevelBytes.Length);
            }

            File.Create(Path.Combine(settings.GDFolderPath, "0.mp3")).Dispose();

            return settings;
        }

        private class TestFileManagerSettings : IFileManagerSettings
        {
            private readonly string appDataFolderPath;

            public string AppDataFolderPath => appDataFolderPath;

            public string BetterBPMGDAppDataFolderPath => Path.Combine(AppDataFolderPath, "BetterBPMProgram\\");

            public string GDFolderPath => Path.Combine(AppDataFolderPath, "GDProgram\\");

            public string BetterBPMGDTemporaryFolderPath => Path.Combine(BetterBPMGDAppDataFolderPath, "Temp\\");

            public string BetterBPMGDLevelsSavesCopiesFolderPath => Path.Combine(BetterBPMGDAppDataFolderPath, "Copies\\");

            public string BetterBPMGDCurrentLevelFolderPath => Path.Combine(BetterBPMGDAppDataFolderPath, "Current\\");

            public string GdLevelsSavePath { get; set; }
            public string LocalLevelsCopyPath { get; set; }
            public string DecryptedLocalLevelsCopyPath { get; set; }
            public string CurrentLevelPath { get; set; }
            public string MinimalLevelPath { get; set; }
            public string ProjectsFolderPath { get; set; }
            public string BackupFolderPath { get; set; }
            public bool CreateLevelsBackup { get; set; }
            public bool AutoSongId { get; set; }

            public TestFileManagerSettings() => ResetAll();

            public TestFileManagerSettings(string testEnvironmentPath)
            {
                appDataFolderPath = testEnvironmentPath;

                ResetAll();
            }

            public TestFileManagerSettings(string gdLevelsSavePath, string localLevelsCopyPath, string decryptedLocalLevelsCopyPath, string currentLevelPath, string minimalLevelPath, string projectsFolderPath, string backupFolderPath, bool createLevelsBackup, bool autoSongId)
            {
                GdLevelsSavePath = gdLevelsSavePath;
                LocalLevelsCopyPath = localLevelsCopyPath;
                DecryptedLocalLevelsCopyPath = decryptedLocalLevelsCopyPath;
                CurrentLevelPath = currentLevelPath;
                MinimalLevelPath = minimalLevelPath;
                ProjectsFolderPath = projectsFolderPath;
                BackupFolderPath = backupFolderPath;
                CreateLevelsBackup = createLevelsBackup;
                AutoSongId = autoSongId;
            }

            public string? GetDefault(string propertyName)
            {
                throw new NotImplementedException();
            }

            public void ResetAll()
            {
                GdLevelsSavePath = Path.Combine(GDFolderPath, "Levels.dat");
                LocalLevelsCopyPath = Path.Combine(BetterBPMGDLevelsSavesCopiesFolderPath, "LevelsCopy.dat");
                DecryptedLocalLevelsCopyPath = Path.Combine(BetterBPMGDLevelsSavesCopiesFolderPath, "LevelsCopy.xml");
                CurrentLevelPath = Path.Combine(BetterBPMGDCurrentLevelFolderPath, "Level.xml");
                MinimalLevelPath = Path.Combine(BetterBPMGDCurrentLevelFolderPath, "Minimal.xml");
                ProjectsFolderPath = Path.Combine(BetterBPMGDAppDataFolderPath, "Projects\\");
                BackupFolderPath = Path.Combine(GDFolderPath, "Backups\\");
                CreateLevelsBackup = true;
                AutoSongId = false;
            }
        }
    }
}
