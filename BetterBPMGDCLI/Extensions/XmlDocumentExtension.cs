using System.Xml;
using System.Xml.Linq;

namespace BetterBPMGDCLI.Extensions
{
    public static class XmlDocumentExtension
    {
        public static XDocument ToXDocument(this XmlDocument xmlDocument)
        {
            using (XmlNodeReader xmlNodeReader = new(xmlDocument))
            {
                xmlNodeReader.MoveToContent();

                return XDocument.Load(xmlNodeReader);
            }
        }
    }
}
