using BetterBPMGDCLI.Extensions;
using BetterBPMGDCLI.Models.Ciphers;
using BetterBPMGDCLI.Utils;
using System.Xml.Linq;

namespace BetterBPMGDCLI.Models.Level
{
    public class LocalLevel(string key, string name, string description, int initialOfficialSongId, int initialCustomSongId, LocalLevelData? data, XElement level)
    {
        public string LevelKey { get; set; } = key;
        public string LevelName { get; set; } = name;
        public string LevelDescription { get; set; } = description;
        public int InitialOfficialSongId { get; set; } = initialOfficialSongId;
        public int InitialCustomSongId { get; set; } = initialCustomSongId;
        public LocalLevelData? LevelData { get; set; } = data;
        public XElement XmlLevel { get; set; } = level;

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

        public static LocalLevel Parse(string level, string levelKey) => Parse(XElement.Load(level), levelKey);

        public static LocalLevel Parse(XElement level, string levelKey)
        {
            (XElement name, XElement description, XElement officialSong, XElement customSong, XElement data) = GetLevelElements(level);

            return new(levelKey, name.Value, description.Value, int.Parse(officialSong.Value), int.Parse(customSong.Value), LocalLevelData.Parse(new LocalLevelDataCipher(data.Value).Decode()), level);
        }

        private static (XElement nameElement, XElement descriptionElement, XElement officialSongIdElement, XElement customSongIdElement, XElement levelDataElement) GetLevelElements(XElement level)
        {
            XElement name = level.FindElementByKeyValue(Constants.NameElementKey, Constants.StringElementTag) ?? new(Constants.NotFoundPlaceholder);
            XElement description = level.FindElementByKeyValue(Constants.DescriptionElementKey, Constants.StringElementTag) ?? new(Constants.NotFoundPlaceholder);
            XElement officialSong = level.FindElementByKeyValue(Constants.OfficialSongIdElementKey, Constants.StringElementTag) ?? new(Constants.NotFoundPlaceholder) { Value = "0" };
            XElement customSong = level.FindElementByKeyValue(Constants.CustomSongIdElementKey, Constants.StringElementTag) ?? new(Constants.NotFoundPlaceholder) { Value = "0" };
            XElement data = level.FindElementByKeyValue(Constants.LevelDataElementKey, Constants.StringElementTag) ?? new(Constants.NotFoundPlaceholder);

            return (name, description, officialSong, customSong, data);
        }
    }
}
