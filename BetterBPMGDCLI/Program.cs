using BetterBPMGDCLI.CLI;
using BetterBPMGDCLI.Managers;
using BetterBPMGDCLI.Models.Settings;
using System.CommandLine;

namespace BetterBPMGDCLI
{
    internal class Program
    {
        static async Task<int> Main(string[] args)
        {
            WorkFlowManager workFlowManager = new WorkFlowManager(new ConfigManager(new PathSettings()));

            Option<string> testOption = new(name: "--test", description: "Test function");

            RootCommand rootCommand = new("Test");

            rootCommand.AddOption(testOption);

            rootCommand.SetHandler(Console.WriteLine, testOption);

            NewProject newProjectCommand = new(workFlowManager);
            NewTiming newTimingCommand = new(workFlowManager);

            IReadOnlyCollection<ICommand> commands = [ new TestCommand(), new NewCommand(newProjectCommand, newTimingCommand) ];

            foreach (ICommand command in commands)
            {
                rootCommand.Add(command.BuildCommand());
            }

            return await rootCommand.InvokeAsync(args);
        }
    }
}
