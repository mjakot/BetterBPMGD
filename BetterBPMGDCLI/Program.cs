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
            WorkFlowManager workFlowManager = StartupManager.Startup(new PathSettings());

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

            workFlowManager.configManager.Dispose();

            return await rootCommand.InvokeAsync(args);
        }
    }
}
