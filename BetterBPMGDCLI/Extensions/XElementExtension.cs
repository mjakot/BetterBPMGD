using BetterBPMGDCLI.Models.Level;
using System.Xml.Linq;

namespace BetterBPMGDCLI.Extensions
{
    public static class XElementExtension
    {
        public static XElement? FindElementByKeyValue(this XElement xElement, string keyTag, string keyValue, string targetTag)                                                                                                                
        {
            XElement? element = (XElement?)(from key in xElement.Descendants(keyTag)
                                            where key.Value == keyValue
                                            select key.NextNode).FirstOrDefault();

            if (element?.Name != targetTag) return null;
            
            return element;
        }

        public static XElement? FindElementByKeyValue(this XElement xElement, string keyValue, string targetTag) => xElement.FindElementByKeyValue(LocalLevel.KeyElementTag, keyValue, targetTag);
    }
}
