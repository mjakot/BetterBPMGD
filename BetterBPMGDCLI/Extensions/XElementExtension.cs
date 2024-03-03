using BetterBPMGDCLI.Managers;
using BetterBPMGDCLI.Managers.WorkFlow;
using BetterBPMGDCLI.Utils;
using System.Xml.Linq;

namespace BetterBPMGDCLI.Extensions
{
    public static class XElementExtension
    {
        public static XElement? FindElementByKeyValue(this XElement xElement, string keyTag, string keyValue, string targetTag)
            => xElement.FindAllElementsByKeyValue(keyTag, keyValue, targetTag)
                        ?.FirstOrDefault();

        public static XElement? FindElementByKeyValue(this XElement xElement, string keyValue, string targetTag)
            => xElement.FindElementByKeyValue(Constants.KeyElementTag, keyValue, targetTag);

        public static IEnumerable<XElement> FindAllElementsByKeyValue(this XElement xElement, string keyTag, string keyValue, string targetTag)
            => from key in xElement.Descendants(keyTag)
               where key.Value == keyValue
               let nextElement = key.NextNode as XElement
               where nextElement?.Name == targetTag
               select nextElement;

        public static IEnumerable<XElement> FindAllElementsByKeyValue(this XElement xElement, string keyValue, string targetTag)
            => xElement.FindAllElementsByKeyValue(Constants.KeyElementTag, keyValue, targetTag);

        public static IEnumerable<LevelPreview?> FindAllLevelsByName(this XElement xElement, string levelName, bool ignoreCase = false)
        {

            foreach (XElement? level in (from nameKey in xElement.Descendants(Constants.KeyElementTag)
                                            where ignoreCase ? nameKey.Value == Constants.NameElementKey : nameKey.Value.ToLower() == Constants.NameElementKey
                                            let nameTag = nameKey.NextNode as XElement
                                            where ignoreCase ? nameTag?.Name == Constants.StringElementTag : nameTag?.Name.ToString().ToLower() == Constants.StringElementTag
                                            where ignoreCase ? nameTag?.Value == levelName : nameTag?.Value.ToLower() == levelName
                                            select nameKey.Parent)
                                        as IEnumerable<XElement?> ?? [])

                yield return new((level?.PreviousNode as XElement)?.Value ?? Constants.NotFoundPlaceholder,
                                    level?.FindElementByKeyValue(Constants.NameElementKey, Constants.StringElementTag)?.Value ?? Constants.NotFoundPlaceholder,
                                    level?.FindElementByKeyValue(Constants.DescriptionElementKey, Constants.StringElementTag)?.Value ?? Constants.NotFoundPlaceholder,
                                    int.Parse(level?.FindElementByKeyValue(Constants.ObjectsCountElementKey, Constants.IntegerElementTag)?.Value ?? "0"),
                                    (LevelLength)int.Parse(level?.FindElementByKeyValue(Constants.LengthElementKey, Constants.IntegerElementTag)?.Value ?? "0"));
        }
    }
}
