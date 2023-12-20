using BetterBPMGDCLI.Extensions;
using BetterBPMGDCLI.Models.LevelsSave.Ciphers;
using BetterBPMGDCLI.Models.LevelsSave.Ciphers.Factories;
using BetterBPMGDCLI.Models.LevelsSave.Level;
using BetterBPMGDCLI.Models.Settings;
using System.Xml;
using System.Xml.Linq;

namespace BetterBPMGDCLI.Models
{
    public class FileManager
    {
        IFileManagerSettings settings;

        public FileManager(IFileManagerSettings settings) => this.settings = settings;

        public bool CopyLocalLevels() => CopyTo(settings.GdLevelsSavePath, settings.LocalLevelsCopyPath);

        public bool UpdateLocalLevels()
        {
            bool result = true;

            if (settings.CreateLevelsBackup) result &= BackupFile(settings.GdLevelsSavePath, settings.BackupFolderPath);

            return result &= CopyTo(settings.DecryptedLocalLevelsCopyPath, settings.GdLevelsSavePath);
        }

        public bool DecryptLocalLevels(ILocalLevelCipherFactory levelCipherFactory)
        {
            string levels = ReadFile(settings.LocalLevelsCopyPath);

            if (string.IsNullOrEmpty(levels)) return false;

            ILocalLevelCipher localLevelCipher = levelCipherFactory.Decode(levels);

            return WriteToFile(settings.DecryptedLocalLevelsCopyPath, localLevelCipher.DataString);
        }

        public bool FindLocalLevel(string levelKey)
        {
            if (string.IsNullOrEmpty(levelKey)) return false;

            XElement levels = XElement.Load(settings.DecryptedLocalLevelsCopyPath);

            XElement? levelTag = levels.FindElementByKeyValue("k", levelKey, "d");

            if (levelTag is null) return false;

            XElement keyTag = new("k", levelKey);

            keyTag.Add(levelTag);

            return SaveMinifiedXML(keyTag);
        }

        public LocalLevelData? GetLocalLevel(ILocalLevelCipherFactory localLevelDataCipherFactory)
        {
            XElement level = XElement.Load(settings.TemporaryLevelPath);
            XElement? levelKey = level.FindElementbyTag("k");
            XElement? levelData = level.FindElementByKeyValue("k", "k4", "s");

            if (levelKey is null || levelData is null) return null;

            ILocalLevelCipher localLevelDataCipher = localLevelDataCipherFactory.Decode(levelData.Value);

            return new(levelKey.Value, localLevelDataCipher.DataString);
        }

        public bool SaveLocalLevel(LocalLevelData localLevelData)
        {
            XElement level = XElement.Load(settings.TemporaryLevelPath);
            XElement? levelKey = level.FindElementbyTag("k");
            XElement? levelData = level.FindElementByKeyValue("k", "k4", "s");

            if (levelKey is null || levelData is null) return false;
            if (levelKey.Value != localLevelData.LevelKey) return false;

            levelData.Value = localLevelData.LevelData;

            return SaveMinifiedXML(level);
        }

        private bool BackupFile(string filePath, string backupFolderPath)
        {
            string fileName = Path.GetFileName(filePath);
            string destinationPath = Path.Combine(backupFolderPath, fileName);

            if (File.Exists(destinationPath))
            {
                string timestamp = DateTime.Now.ToString("yyyy-MM-dd-HH_mm_ss_fff");
                string newFileName = $"{fileName}_{timestamp}";

                destinationPath = Path.Combine(destinationPath, newFileName);
            }

            return CopyTo(filePath, destinationPath);
        }

        private bool CopyTo(string source, string destination)
        {
            const int bufferSize = 4096;

            using FileStream sourceStream = new(source, FileMode.Open, FileAccess.Read);
            using FileStream destinationStream = new(destination, FileMode.Create, FileAccess.Write);

            int bytesRead = 0;

            byte[] buffer = new byte[bufferSize];

            try
            {
                while ((bytesRead = sourceStream.Read(buffer, 0, bufferSize)) > 0) destinationStream.Write(buffer, 0, bytesRead);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        private string ReadFile(string filePath)
        {
            if (!File.Exists(filePath)) return string.Empty;

            try
            {
                using FileStream fileStream = new(filePath, FileMode.Open, FileAccess.Read);
                using StreamReader streamReader = new(fileStream);

                return streamReader.ReadToEnd();
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        private bool WriteToFile(string filePath, string content, FileMode fileMode = FileMode.Create)
        {
            try
            {
                using FileStream fileStream = new(filePath, fileMode, FileAccess.Write);
                using StreamWriter streamWriter = new(filePath);

                streamWriter.Write(content);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private bool SaveMinifiedXML(XElement xml)
        {
            try
            {
                using XmlWriter xmlWriter = XmlWriter.Create(settings.TemporaryLevelPath);

                xml.Save(xmlWriter);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
