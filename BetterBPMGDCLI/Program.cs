using System.Reflection;

namespace BetterBPMGDCLI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0) Console.WriteLine($"version: {Assembly.GetExecutingAssembly().GetName().Version}");
        }
    }
}
