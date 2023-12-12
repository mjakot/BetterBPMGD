using BetterBPMGDCLI.Models.LevelsSave.Ciphers;
using BetterBPMGDCLI.Models.LevelsSave.Ciphers.Factories;
using BetterBPMGDCLI.Models.LevelsSave.Level;
using System.Xml;
using System.Xml.Linq;

namespace BetterBPMGDCLI.Extensions
{
    public static class XDocumentExtension
    {
        public static XmlDocument ToXmlDocument(this XDocument xDocument)
        {
            var xmlDocument = new XmlDocument();
            using (var xmlReader = xDocument.CreateReader())
            {
                xmlDocument.Load(xmlReader);
            }
            return xmlDocument;
        }

        public static void ModifyElementValue(this XDocument document, string key, string keyValue, string element, string newValue)
        {
            XElement? replaceElement = document.FindElementByKeyValue(key, keyValue, element);

            if (replaceElement is null) return;

            XElement newContent = XElement.Parse($"<{element}>{newValue}</{element}>");
            
            replaceElement.ReplaceNodes(newContent.Nodes());
        }

        public static XElement? FindElementByKeyValue(this XDocument document, string key, string keyValue, string element)
        {
            XElement? elementKey = document.Descendants(key).FirstOrDefault(e => e.Value == keyValue);

            if (elementKey is not null) return elementKey.ElementsAfterSelf(element).FirstOrDefault();

            return null;
        }

        public static XElement? FindLevelByKey(this XDocument levels, string key) => FindElementByKeyValue(levels, "k", key, "d");

        public static XElement? FindLevelData(this XDocument level) => FindElementByKeyValue(level, "k", "k4", "s");

        public static LocalLevel ToLocalLevel(this XDocument level, int localLevelId)
        {
            XElement? levelData = level.FindLevelData();

            LocalLevelDataCipher localLevelDataCipher = LocalLevelDataCipherFactory.Decode(new(levelData?.Value ?? string.Empty));

            LocalLevelData localLevelData = new(localLevelDataCipher.DataString);

            return new(localLevelId, localLevelData);
        }
    }
}
