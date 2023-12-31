using BetterBPMGDCLI.Models.FileManagement;
using BetterBPMGDCLI.Models.LevelsSave.Ciphers.Factories;
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

        [Fact(Skip = "later")]
        public void UpdateLocalLevels_BackupLevelsTrue_SavesLevelAndBackupPrevious()
        {
            IFileManagerSettings settings = fixture.CreateEnvironment(nameof(UpdateLocalLevels_BackupLevelsTrue_SavesLevelAndBackupPrevious));

            FileManager fileManager = new(settings);

            LocalLevelsCipherFactory factory = new LocalLevelsCipherFactory();


        }
    }
}
