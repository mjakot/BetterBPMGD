using BetterBPMGDCLI.CLI;
using System.CommandLine;

namespace BetterBPMGDCLI
{
    internal class Program
    {
        static async Task<int> Main(string[] args)
        {
            Option<string> testOption = new(name: "--test", description: "Test function");

            RootCommand rootCommand = new("Test");

            rootCommand.AddOption(testOption);

            rootCommand.SetHandler(Console.WriteLine, testOption);

            rootCommand.Add(new TestCommand().BuildCommand());

            return await rootCommand.InvokeAsync(args);
        }
    }
}
