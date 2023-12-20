using System.Xml.Linq;

namespace BetterBPMGDCLI.Extensions
{
    public static class XElementExtension
    {
        public static XElement? FindElementbyTag(this XElement xElement, string tag) => xElement.Descendants(tag).FirstOrDefault();

        public static XElement? FindElementByKeyValue(this XElement xElement, string keyTag, string keyValue, string targetTag)
        {
            XElement? keyElement = xElement.Descendants(keyTag).FirstOrDefault(e => (string)e == keyValue);

            if (keyElement is null) return null;

            return keyElement.ElementsAfterSelf(targetTag).FirstOrDefault();
        }
    }
}
