using BetterBPMGDCLI.Extensions;
using System.Xml.Linq;

namespace BetterBPMGDCLI.Models.Level
{
    public class LocalLevel
    {
        public const string KeyElementTag = "k";
        public const string StringElementTag = "s";
        public const string IntegerElementTag = "i";
        public const string DictionaryElementTag = "i";

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

        public LocalLevel(string key, string name, string description, int initialOfficialSongId, int initialCustomSongId, LocalLevelData? data, XElement level)
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
            (XElement name, XElement description, XElement officialSong, XElement customSong, XElement data) = GetLevelElements(XmlLevel);
            
            name.Value = LevelName;
            description.Value = LevelDescription;
            officialSong.Value = InitialCustomSongId.ToString();
            customSong.Value = InitialCustomSongId.ToString();
            data.Value = LevelData?.Encode(true) ?? string.Empty;

            return XmlLevel.ToString(SaveOptions.DisableFormatting);
        }

        public static LocalLevel Parse(string level, string levelKey) => Parse(XElement.Parse(level), levelKey);

        public static LocalLevel Parse(XElement level, string levelKey)
        {
            (XElement name, XElement description, XElement officialSong, XElement customSong, XElement data) = GetLevelElements(level);

            return new(levelKey, name.Value, description.Value, int.Parse(officialSong.Value), int.Parse(customSong.Value), LocalLevelData.Parse(data.Value), level);
        }

        private static (XElement nameElement, XElement descriptionElement, XElement officialSongIdElement, XElement customSongIdElement, XElement levelDataElement) GetLevelElements(XElement level)
        {
            XElement name = level.FindElementByKeyValue(NameElementKey, StringElementTag) ?? new("NotFound");
            XElement description = level.FindElementByKeyValue(DescriptionElementKey, StringElementTag) ?? new("NotFound");
            XElement officialSong = level.FindElementByKeyValue(OfficialSongIdElementKey, StringElementTag) ?? new("NotFound");
            XElement customSong = level.FindElementByKeyValue(CustomSongIdElementKey, StringElementTag) ?? new("NotFound");
            XElement data = level.FindElementByKeyValue(LevelDataElementKey, StringElementTag) ?? new("NotFound");

            return (name, description, officialSong, customSong, data);
        }
    }
}
