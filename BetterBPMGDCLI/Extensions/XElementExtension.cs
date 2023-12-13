using System.Xml.Linq;

namespace BetterBPMGDCLI.Extensions
{
    public static class XElementExtension
    {
        public static XDocument ToXDocument(this XElement xElement) => new XDocument(xElement);
    }
}
