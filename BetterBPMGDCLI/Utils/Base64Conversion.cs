namespace BetterBPMGDCLI.Utils
{
    public class Base64Conversion
    {
        public string FromBase64UrlToBase64(string base64urlString)
        {
            base64urlString = base64urlString.Replace('-', '+').Replace('_', '/').Replace("\0", string.Empty);

            int remaining = base64urlString.Length % 4;

            if (remaining > 0) { base64urlString += new string('=', 4 - remaining); }

            return base64urlString;
        }
    }
}
