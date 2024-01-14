namespace BetterBPMGDCLI.Utils
{
    public class FileUtility
    {
        public static string HeavyReadFromFile(string path)
        {
            using StreamReader reader = new(path);

            return reader.ReadToEnd();
        }

        public static void HeavyWriteToFile(string path, string content)
        {
            using StreamWriter writer = new(path);

            writer.Write(content);
        }

        public static string ReadFromFile(string path) => File.ReadAllText(path);

        public static void WriteToFile(string path, string content) => File.WriteAllText(path, content);

        public static void CopyFile(string source, string destination) => File.Copy(source, destination, true);

        public static void CreateNewFolder(string path) => Directory.CreateDirectory(path);
    }
}
