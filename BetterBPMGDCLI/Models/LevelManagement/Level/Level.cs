using BetterBPMGDCLI.Extensions;
using BetterBPMGDCLI.Models.LevelManagement.Level;
using System.Runtime.InteropServices;
using System.Xml.Linq;

namespace BetterBPMGDCLI.Models.LevelsSave.Level
{
    public class Level
    {
        public const string KeyElementTag = "k";
        public const string StringElementTag = "s";
        public const string IntegerElementTag = "i";

        public const string NameElementKey = "k2";
        public const string DescriptionElementKey = "k3";
        public const string LevelDataElementKey = "k4";
        public const string OfficialSongIdElementKey = "k8";
        public const string CustomSongIdElementKey = "k45";

        public string LevelKey { get; set; }
        public string LevelName { get; set; }
        public string LevelDescription { get; set; }
        public int InitialOfficialSongId { get; set; }
        public int InitialCustomSongId { get; set; }
        public LocalLevelData? LevelData { get; set; }
        public XElement XmlLevel {  get; set; }

        public Level(string key, string name, string description, int initialOfficialSongId, int initialCustomSongId, LocalLevelData? data, XElement level)
        {
            LevelKey = key;
            LevelName = name;
            LevelDescription = description;
            InitialOfficialSongId = initialOfficialSongId;
            InitialCustomSongId = initialCustomSongId;
            LevelData = data;
            XmlLevel = level;
        }

        public string Encode()
        {
            throw new NotImplementedException();
        }

        public static Level? Parse(string data, string levelKey)
        {
            try
            {
                int officialSong;
                int customSong;

                XElement level = XElement.Parse(data);
                string name = level.FindElementByKeyValue(KeyElementTag, NameElementKey, StringElementTag)?.Value ?? string.Empty;
                string description = level.FindElementByKeyValue(KeyElementTag, DescriptionElementKey, StringElementTag)?.Value ?? string.Empty;
                int.TryParse(level.FindElementByKeyValue(KeyElementTag, OfficialSongIdElementKey, IntegerElementTag)?.Value ?? string.Empty, out officialSong);
                int.TryParse(level.FindElementByKeyValue(KeyElementTag, CustomSongIdElementKey, IntegerElementTag)?.Value ?? string.Empty, out customSong);
                LocalLevelData? levelData = (LocalLevelData?)LocalLevelData.Parse(level.FindElementByKeyValue(KeyElementTag, LevelDataElementKey, StringElementTag)?.Value ?? string.Empty);

                return new Level(levelKey, name, description, officialSong, customSong, levelData, level);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
