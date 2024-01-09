using BetterBPMGDCLI.Extensions;
using BetterBPMGDCLI.Models.Settings.Interfaces;
using Common;
using NAudio.Wave;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace BetterBPMGDCLI.Models.FileManagement
{
    public class FileManager
    {
        IFileManagerSettings settings;

        public FileManager(IFileManagerSettings settings) => this.settings = settings;

        private bool CreateNewProject(string projectName, ulong songId)
        {
            string songPath = Path.Combine(settings.GDFolderPath, songId.ToString() + ".mp3");

            if (!File.Exists(songPath)) return false;

            return CreateNewProject(projectName, songPath);
        }

        private bool AddTiming(string projectName, Timing timing)
        {
            string path = Path.Combine(settings.ProjectsFolderPath, $"{projectName}\\", settings.TimingsListPath);

            if (!File.Exists(path)) return false;

            return WriteToFile(path, timing.Serialize(), FileMode.Append);
        }

        private bool AddTimings(string projectName, IEnumerable<Timing> timings)
        {
            string path = Path.Combine(settings.ProjectsFolderPath, $"{projectName}\\", settings.TimingsListPath);

            if (!File.Exists(path)) return false;

            StringBuilder content = new();

            foreach (Timing timing in timings) content.AppendLine(timing.Serialize());

            return WriteToFile(path, content.ToString(), FileMode.Append);
        }

        private bool BackupFile(string filePath, string backupFolderPath)
        {
            string fileName = Path.GetFileName(filePath.Replace(".", $"_{GenerateTimestamp()}."));
            string destinationPath = Path.Combine(backupFolderPath, fileName);

            return CopyTo(filePath, destinationPath);
        }

        private LocalLevelsCipher? DecryptLocalLevels(ILocalLevelCipherFactory levelCipherFactory)
        {
            string levels = ReadFromFile(settings.GdLevelsSavePath);
            
            if (string.IsNullOrEmpty(levels)) return null;

            ILocalLevelCipher localLevelsCipher = levelCipherFactory.Decode(levels);

            WriteToFile(settings.GdLevelsSavePath, localLevelsCipher.DataString);

            return (LocalLevelsCipher?)localLevelsCipher;
        }

        private XElement? CreateNewLevel(string levelName)
        {
            if (string.IsNullOrEmpty(levelName)) return null;

            XElement minimalLevel = XElement.Load(settings.MinimalLevelPath);
            XElement? levelNameTag = minimalLevel.FindElementByKeyValue("k", "k2", "s");

            if (levelNameTag is null) return null;

            levelNameTag.Value = levelName;

            minimalLevel.Elements("s")
                         .FirstOrDefault()
                         ?.ReplaceWith(levelNameTag);

            return minimalLevel;
        }

        private LocalLevelData? InsertTimings(string projectName, LocalLevelData levelData)
        {
            if (string.IsNullOrEmpty(projectName)) return null;

            levelData.Add(GetTimings(projectName) ?? []);
            levelData.SongDurationMS = (ulong)new Mp3FileReader(Directory.GetFiles(Path.Combine(settings.ProjectsFolderPath, projectName), "*.mp3").First()).TotalTime.Milliseconds;

            return new("k_-1", levelData.Encode(true));
        }

        private bool InsertLocalLevel(XElement level)
        {
            XElement levels = XElement.Load(settings.GdLevelsSavePath);
            XElement keyTag = new("k", "k_-1");

            levels.Descendants().Where(e => e.IsEmpty && !e.HasAttributes).FirstOrDefault()?.AddAfterSelf(keyTag, level);

            return SaveMinifiedXML(levels, settings.GdLevelsSavePath);
        }

        private bool WriteToFile(string filePath, string content, FileMode fileMode = FileMode.Create)
        {
            try
            {
                using FileStream fileStream = new(filePath, fileMode, FileAccess.Write);
                using StreamWriter streamWriter = new(fileStream);

                streamWriter.Write(content);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private bool CreateNewProject(string projectName, string songPath)
        {
            if (string.IsNullOrEmpty(projectName) || string.IsNullOrEmpty(songPath)) return false;

            string songName = Path.GetFileName(songPath);
            string fullProjectPath = Path.Combine(settings.ProjectsFolderPath, projectName);
            string timingsPath = Path.Combine(fullProjectPath, settings.TimingsListPath);

            if (Directory.Exists(fullProjectPath))
            {
                string newProjectName = $"{projectName}_{GenerateTimestamp()}";

                fullProjectPath = Path.Combine(settings.ProjectsFolderPath, newProjectName);
            }

            Directory.CreateDirectory(fullProjectPath);

            File.Create(timingsPath).Close();

            return CopyTo(songPath, Path.Combine(fullProjectPath, songName));
        }

        private bool SaveMinifiedXML(XElement xml, string path, bool omitXmlDeclaration = false, bool indent = false)
        {
            try
            {
                XmlWriterSettings writerSettings = new()
                {
                    OmitXmlDeclaration = omitXmlDeclaration,
                    Indent = indent
                };

                using XmlWriter xmlWriter = XmlWriter.Create(path, writerSettings);

                xml.Save(xmlWriter);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private IEnumerable<Timing>? GetTimings(string projectName)
        {
            string path = Path.Combine(settings.ProjectsFolderPath, $"{projectName}\\", settings.TimingsListPath);

            if (!File.Exists(path)) yield break;

            string[] serializedTimings = ReadFromFile(path).Split(Environment.NewLine);

            foreach (string timing in serializedTimings)
                if (timing != string.Empty)
                    yield return TimingExtension.Deserialize(timing);
        }

        private string ReadFromFile(string filePath)
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

        private bool CopyTo(string sourcePath, string destinationPath)
        {
            const int bufferSize = 4096;

            using FileStream sourceStream = new(sourcePath, FileMode.Open, FileAccess.Read);
            using FileStream destinationStream = new(destinationPath, FileMode.Create, FileAccess.Write);

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

        private string GenerateTimestamp() => DateTime.Now.ToString("yyyy-MM-dd-HH_mm_ss_fff");
    }
}
