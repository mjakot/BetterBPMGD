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
    }
}
