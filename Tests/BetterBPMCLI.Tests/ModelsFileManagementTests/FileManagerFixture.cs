using BetterBPMGDCLI.Models.Settings.Interfaces;
using System.Text;

namespace BetterBPMCLI.Tests.ModelsFileManagementTests
{
    public class FileManagerFixture : IDisposable
    {
        private static int counter = 0;

        public const string MinimalLevelsDecrypted = """<?xml version="1.0"?><plist version="1.0" gjver="2.0"><dict><k>LLM_01</k><d><k>_isArr</k><t/><k>k_0</k><d><k>kCEK</k><i>4</i><k>k2</k><s>minimalLevel</s><k>k4</k><s>H4sIAAAAAAAAC6WTwQ3DMAwDF3IBUZLTBH1lhg7AAbJCh29k5pmgLfohYVM-Swa8PWNuYBqd8M6g905A5jJtJm_gRJgZ7wTRS2YaZ-IFDoT5dwj8j1hOEVWjA19BnHX-DPTTk-zr_xl5ykDUQKUx9MNA_XKgH19mugC1bUU0K-uySZZt16lh1_tQP3KtMNfqGcvY9KHijGDNoUphKlKVq8xV4cKlySBz3SiUixLKQlmozRQsBYtQljI1HLqhPkbZovaPvkXxo0Go3d0eby5QMLtKAwAA</s><k>k101</k><s>0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0</s><k>k13</k><t /><k>k21</k><i>2</i><k>k16</k><i>1</i><k>k80</k><i>19</i><k>k83</k><i>64</i><k>k50</k><i>38</i><k>kI1</k><r>0</r><k>kI2</k><r>0</r><k>kI3</k><r>0</r><k>kI6</k><d><k>0</k><s>0</s><k>1</k><s>0</s><k>2</k><s>0</s><k>3</k><s>0</s><k>4</k><s>0</s><k>5</k><s>0</s><k>6</k><s>0</s><k>7</k><s>0</s><k>8</k><s>0</s><k>9</k><s>0</s><k>10</k><s>0</s><k>11</k><s>0</s><k>12</k><s>0</s><k>13</k><s>0</s></d></d></d></dict></plist>""";
        public const string TestDirectory = "c:\\BetterBPMTest\\";

        public FileManagerFixture() { }

        public void Dispose() { }

        public IFileManagerSettings CreateEnvironment()
        {            
            IFileManagerSettings settings = new TestFileManagerSettings($"Test{++counter}\\");

            if (Directory.Exists(settings.AppDataFolderPath)) Directory.Delete(TestDirectory, true);

            Directory.CreateDirectory(TestDirectory);
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
                // <?xml version="1.0"?><plist version="1.0" gjver="2.0"><dict><k>LLM_01</k><d><k>_isArr</k><t/><k>k_0</k><d><k>kCEK</k><i>4</i><k>k2</k><s>minimalLevel</s><k>k4</k><s>H4sIAAAAAAAAC6WTwQ3DMAwDF3IBUZLTBH1lhg7AAbJCh29k5pmgLfohYVM-Swa8PWNuYBqd8M6g905A5jJtJm_gRJgZ7wTRS2YaZ-IFDoT5dwj8j1hOEVWjA19BnHX-DPTTk-zr_xl5ykDUQKUx9MNA_XKgH19mugC1bUU0K-uySZZt16lh1_tQP3KtMNfqGcvY9KHijGDNoUphKlKVq8xV4cKlySBz3SiUixLKQlmozRQsBYtQljI1HLqhPkbZovaPvkXxo0Go3d0eby5QMLtKAwAA</s><k>k101</k><s>0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0</s><k>k13</k><t /><k>k21</k><i>2</i><k>k16</k><i>1</i><k>k80</k><i>19</i><k>k83</k><i>64</i><k>k50</k><i>38</i><k>kI1</k><r>0</r><k>kI2</k><r>0</r><k>kI3</k><r>0</r><k>kI6</k><d><k>0</k><s>0</s><k>1</k><s>0</s><k>2</k><s>0</s><k>3</k><s>0</s><k>4</k><s>0</s><k>5</k><s>0</s><k>6</k><s>0</s><k>7</k><s>0</s><k>8</k><s>0</s><k>9</k><s>0</s><k>10</k><s>0</s><k>11</k><s>0</s><k>12</k><s>0</s><k>13</k><s>0</s></d></d></d></dict></plist>
                string minimalLevels = """C?xBJJJJJJJJHd9_9?=bZIHLS3]?}X?;bNGHFJLQN\:|YhNOE3__ZCFZIZ_;=QncZ^m8QbN`TM3:Y]ST:ms<NZj⌂<IJe@Oz&⌂hM}x};~3@hJAn`qi_gnzoTj][`~3C~;X|SnM:Y]x;eJN8=A}y\ENaLD@>;X83H8r^m^C8qJXbLcrsDdZgZMNbMNYsY~J}\ZCZ@nX@{R⌂??{8\Z`:⌂nl⌂qYreQR:FQhT=QM`\zdc@XI|ei?dixhOg&A3>cZ==gm`ycojQ>>}9DgrhggG>q9y2YrDQN_LL=ma;CQfR3mz>3Qx_z;8]fm;@^hLx332:l[~e?TM;cFIAs9]]^nnLdim~h]9N_ISSqQ:jIjhEcC⌂MSZ^|B^SQ|H9{`eHq~^=⌂=|^2JBS9@`&{\Lz_i<D|:99>zHH}@N3bhr_H|D?DG[Mdy~O|S^~8nl>FgLcZa;Bd2⌂F_=Y:zlmnHHaz9Q8=\r}@E⌂[FSs^YDRqd[SeRScgo^:Fd>zGR<I\di^lN3⌂oT8mh[j\sSHT⌂M?_YBdIzCZ@3fdHNx9YO~aeJ\A[_~qaGE@{{⌂;Jlea?^rMLDHTm2Ah@jmIIoZaYOD\_QQg82}~⌂iEDO^jA8}dQzZjqisdT@~C<yTdx{^eS\<Jhq8TM[cjBSl⌂x_jlJ^_Q>&D{qcgYe^mcG&e`}T~xJ|JJ""";
                byte[] minimalLevelsBytes = Encoding.UTF8.GetBytes(minimalLevels);

                fs.Write(minimalLevelsBytes, 0, minimalLevelsBytes.Length);
            }

            using (FileStream fs = File.Create(settings.MinimalLevelPath))
            {
                string minimalLevel = """<d><k>k_0</k><d><k>kCEK</k><i>4</i><k>k2</k><s>minimalLevel</s><k>k4</k><s>H4sIAAAAAAAAC6WTwQ3DMAwDF3IBUZLTBH1lhg7AAbJCh29k5pmgLfohYVM-Swa8PWNuYBqd8M6g905A5jJtJm_gRJgZ7wTRS2YaZ-IFDoT5dwj8j1hOEVWjA19BnHX-DPTTk-zr_xl5ykDUQKUx9MNA_XKgH19mugC1bUU0K-uySZZt16lh1_tQP3KtMNfqGcvY9KHijGDNoUphKlKVq8xV4cKlySBz3SiUixLKQlmozRQsBYtQljI1HLqhPkbZovaPvkXxo0Go3d0eby5QMLtKAwAA</s><k>k101</k><s>0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0</s><k>k13</k><t /><k>k21</k><i>2</i><k>k16</k><i>1</i><k>k80</k><i>19</i><k>k83</k><i>64</i><k>k50</k><i>38</i><k>kI1</k><r>0</r><k>kI2</k><r>0</r><k>kI3</k><r>0</r><k>kI6</k><d><k>0</k><s>0</s><k>1</k><s>0</s><k>2</k><s>0</s><k>3</k><s>0</s><k>4</k><s>0</s><k>5</k><s>0</s><k>6</k><s>0</s><k>7</k><s>0</s><k>8</k><s>0</s><k>9</k><s>0</s><k>10</k><s>0</s><k>11</k><s>0</s><k>12</k><s>0</s><k>13</k><s>0</s></d></d></d>""";
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

            public TestFileManagerSettings(string testEnvironmentPath) : this() => appDataFolderPath = Path.Combine(TestDirectory, testEnvironmentPath);

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
