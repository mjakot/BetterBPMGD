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

        public static IReadOnlyList<XElement?>? FindAllElementsByKeyValue(this XElement xElement, string keyTag, string keyValue, string targetTag)
        {
            return ( from key in xElement.Descendants(keyTag)
                     where key.Value == keyValue
                     let targetElement = key.NextNode as XElement
                     where targetElement.Name == targetTag
                     select key.NextNode ) 
                     as IReadOnlyList<XElement?>;
        }

        public static IReadOnlyList<XElement?>? FindAllElementsByKeyValue(this XElement xElement, string keyValue, string targetTag)
            => xElement.FindAllElementsByKeyValue(Constants.KeyElementTag, keyValue, targetTag);

        public static IEnumerable<LevelPreview?>? FindAllLevelsByName(this XElement xElement, string levelName)
        {
            IReadOnlyList<XElement?>? levels = ( from level in xElement.Descendants(Constants.NameElementKey)
                                                 where level.Value == levelName
                                                 select level.Parent )
                                                 as IReadOnlyList<XElement?>;

            foreach (XElement? level in levels ?? [])
                yield return new( (level?.PreviousNode as XElement)?.Value ?? Constants.NotFoundPlaceholder,
                                    level?.FindElementByKeyValue(Constants.NameElementKey, Constants.StringElementTag)?.Value ?? Constants.NotFoundPlaceholder,
                                    level?.FindElementByKeyValue(Constants.DescriptionElementKey, Constants.StringElementTag)?.Value ?? Constants.NotFoundPlaceholder,
                                    int.Parse(level?.FindElementByKeyValue(Constants.ObjectsCountElementKey, Constants.IntegerElementTag)?.Value ?? "0"),
                                    (LevelLength)int.Parse(level?.FindElementByKeyValue(Constants.LengthElementKey, Constants.IntegerElementTag)?.Value ?? "0") );
        }
    }
}
