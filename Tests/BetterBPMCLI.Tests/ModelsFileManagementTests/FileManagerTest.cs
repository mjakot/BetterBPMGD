using BetterBPMGDCLI.Models.FileManagement;
using BetterBPMGDCLI.Models.LevelsSave.Ciphers.Factories;
using BetterBPMGDCLI.Models.LevelsSave.Level;
using BetterBPMGDCLI.Models.Settings.Interfaces;

namespace BetterBPMCLI.Tests.ModelsFileManagementTests
{
    [Collection("FixtureCollection")]
    public class FileManagerTest
    {
        private readonly FileManagerFixture fixture;

        public FileManagerTest(FileManagerFixture fixture) => this.fixture = fixture;

        [Fact]
        public void CreateNewProject_ValidInputs_EmptyProject()
        {
            IFileManagerSettings settings = fixture.CreateEnvironment(nameof(CreateNewProject_ValidInputs_EmptyProject));

            FileManager manager = new(settings);

            string projectname = "test";
            string expectedDirectory = Path.Combine(settings.ProjectsFolderPath, "test");
            string expectedAudio = Path.Combine(expectedDirectory, "0.mp3");

            ulong songId = 0;



            bool created = manager.CreateNewProject(projectname, songId);


            

            Assert.True(created);
            Assert.True(Directory.Exists(expectedDirectory));
            Assert.True(File.Exists(expectedAudio));
        }

        [Fact]
        public void CopyLocalLevels_LocalLevels_CopiedLocalLevels()
        {
            IFileManagerSettings settings = fixture.CreateEnvironment(nameof(CopyLocalLevels_LocalLevels_CopiedLocalLevels));

            FileManager fileManager = new(settings);



            bool copied = fileManager.CopyLocalLevels();



            Assert.True(copied);
            Assert.True(File.Exists(settings.LocalLevelsCopyPath));
        }

        [Fact]
        public void DecryptLocalLevels_ValidLocalLevels_ValidDecryptedLocalLevels()
        {
            IFileManagerSettings settings = fixture.CreateEnvironment(nameof(DecryptLocalLevels_ValidLocalLevels_ValidDecryptedLocalLevels));

            FileManager fileManager = new(settings);

            LocalLevelsCipherFactory factory = new LocalLevelsCipherFactory();

            string expectedDecryptedLocalLevels = FileManagerFixture.MinimalLevelsDecrypted;

            fileManager.CopyLocalLevels();



            bool decrypted = fileManager.DecryptLocalLevels(factory);



            Assert.True(decrypted);
            Assert.True(File.Exists(settings.DecryptedLocalLevelsCopyPath));
            Assert.Equal(expectedDecryptedLocalLevels, File.ReadAllText(settings.DecryptedLocalLevelsCopyPath));
        }

        [Fact]
        public void FindLocalLevel_ValidKey_SavesToCurrentFolder()
        {
            IFileManagerSettings settings = fixture.CreateEnvironment(nameof(FindLocalLevel_ValidKey_SavesToCurrentFolder));

            FileManager fileManager = new(settings);

            LocalLevelsCipherFactory factory = new LocalLevelsCipherFactory();

            string expectedLevel = FileManagerFixture.MinimalLevel;
            string key = "k_0";

            fileManager.CopyLocalLevels();

            fileManager.DecryptLocalLevels(factory);



            bool found = fileManager.FindLocalLevel(key);



            Assert.True(found);
            Assert.True(File.Exists(settings.CurrentLevelPath));
            Assert.Equal(expectedLevel, File.ReadAllText(settings.CurrentLevelPath));
        }

        [Fact]
        public void CreateNewLevel_ValidMinimalLevel_CopiesMinimalLevelToCurrent()
        {
            IFileManagerSettings settings = fixture.CreateEnvironment(nameof(CreateNewLevel_ValidMinimalLevel_CopiesMinimalLevelToCurrent));

            FileManager fileManager = new(settings);

            string levelName = "test";
            string expectedLevel = """<d><k>kCEK</k><i>4</i><k>k18</k><i>1</i><k>k2</k><s>test</s><k>k4</k><s>H4sIAAAAAAAAC6WTwQ3DMAwDF3IBUZLTBH1lhg7AAbJCh29k5pmgLfohYVM-Swa8PWNuYBqd8M6g905A5jJtJm_gRJgZ7wTRS2YaZ-IFDoT5dwj8j1hOEVWjA19BnHX-DPTTk-zr_xl5ykDUQKUx9MNA_XKgH19mugC1bUU0K-uySZZt16lh1_tQP3KtMNfqGcvY9KHijGDNoUphKlKVq8xV4cKlySBz3SiUixLKQlmozRQsBYtQljI1HLqhPkbZovaPvkXxo0Go3d0eby5QMLtKAwAA</s><k>k101</k><s>0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0</s><k>k13</k><t /><k>k21</k><i>2</i><k>k16</k><i>1</i><k>k80</k><i>62</i><k>k83</k><i>64</i><k>k50</k><i>38</i><k>kI1</k><r>135.998</r><k>kI2</k><r>87.6023</r><k>kI3</k><r>0.3</r><k>kI5</k><i>5</i><k>kI6</k><d><k>0</k><s>0</s><k>1</k><s>0</s><k>2</k><s>0</s><k>3</k><s>0</s><k>4</k><s>0</s><k>5</k><s>0</s><k>6</k><s>0</s><k>7</k><s>0</s><k>8</k><s>0</s><k>9</k><s>0</s><k>10</k><s>0</s><k>11</k><s>0</s><k>12</k><s>0</s><k>13</k><s>0</s></d></d>""";



            bool created = fileManager.CreateNewLevel(levelName);



            Assert.True(created);
            Assert.True(File.Exists(settings.CurrentLevelPath));
            Assert.Equal(expectedLevel, File.ReadAllText(settings.CurrentLevelPath));
        }

        [Fact]
        public void GetLocalLevel_ValidLocalLevelDataFactory_MinimalLevelData()
        {
            IFileManagerSettings settings = fixture.CreateEnvironment(nameof(GetLocalLevel_ValidLocalLevelDataFactory_MinimalLevelData));

            FileManager fileManager = new(settings);

            fileManager.CreateNewLevel("test");

            ILocalLevelCipherFactory factory = new LocalLevelDataCipherFactory();

            string expectedLevelDataString = """kS38,1_40_2_125_3_255_11_255_12_255_13_255_4_-1_6_1000_7_1_15_1_18_0_8_1|1_0_2_102_3_255_11_255_12_255_13_255_4_-1_6_1001_7_1_15_1_18_0_8_1|1_0_2_102_3_255_11_255_12_255_13_255_4_-1_6_1009_7_1_15_1_18_0_8_1|1_255_2_255_3_255_11_255_12_255_13_255_4_-1_6_1002_5_1_7_1_15_1_18_0_8_1|1_40_2_125_3_255_11_255_12_255_13_255_4_-1_6_1013_7_1_15_1_18_0_8_1|1_40_2_125_3_255_11_255_12_255_13_255_4_-1_6_1014_7_1_15_1_18_0_8_1|1_135_2_135_3_135_11_255_12_255_13_255_4_-1_6_1005_5_1_7_1_15_1_18_0_8_1|1_255_2_255_3_255_11_255_12_255_13_255_4_-1_6_1006_5_1_7_1_15_1_18_0_8_1|,kA13,0,kA15,0,kA16,0,kA14,,kA6,1,kA7,1,kA25,0,kA17,1,kA18,0,kS39,0,kA2,0,kA3,0,kA8,0,kA4,0,kA9,0,kA10,0,kA22,0,kA23,0,kA24,0,kA27,1,kA40,1,kA41,1,kA42,1,kA28,0,kA29,0,kA31,1,kA32,1,kA36,0,kA43,0,kA44,0,kA33,1,kA34,1,kA35,0,kA37,1,kA38,1,kA39,1,kA19,0,kA26,0,kA20,0,kA21,0,kA11,0;""";



            LocalLevelData? actualLocalLevelData = fileManager.GetLocalLevel(factory);

            string? actualLocalLevelDataString = actualLocalLevelData?.LevelData;



            Assert.NotNull(actualLocalLevelData);
            Assert.Equal(expectedLevelDataString, actualLocalLevelDataString);
        }

        [Fact(Skip = "later")]
        public void UpdateLocalLevels_BackupLevelsTrue_SavesLevelAndBackupPrevious()
        {
            IFileManagerSettings settings = fixture.CreateEnvironment(nameof(UpdateLocalLevels_BackupLevelsTrue_SavesLevelAndBackupPrevious));

            FileManager fileManager = new(settings);

            LocalLevelsCipherFactory factory = new LocalLevelsCipherFactory();


        }
    }
}
