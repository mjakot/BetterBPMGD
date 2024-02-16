using BetterBPMGDCLI.CLICommands;
using System.CommandLine;

namespace BetterBPMGDCLI.Managers
{
    public class CLIManager
    {
        private bool isRunning = false;

        private readonly WorkFlowManager workFlowManager;

        public CLIManager(WorkFlowManager workFlowManager)
        {
            this.workFlowManager = workFlowManager;
        }

        public async Task RunAsync(string[] args)
        {
            Option<bool> continuous = new(["--continuous", "-c"], description: "Enables the continuous mode", getDefaultValue: () => false);

            RootCommand rootCommand = new()
            {
                StopCommand(),
                new TestCommand().BuildCommand(),
                new NewCommand(new NewProject(workFlowManager), new NewTiming(workFlowManager)).BuildCommand(),
                new SetCommand(new SetCurrentProjectCommand(workFlowManager)).BuildCommand(),
            };

            rootCommand.SetHandler((continuous) =>
            {
                if (continuous)
                    isRunning = true;
            }, continuous);

            _ = await rootCommand.InvokeAsync(args);

            while (isRunning)
            {
                string input = Console.ReadLine() ?? string.Empty;

                _ = await rootCommand.InvokeAsync(input);
            }

            workFlowManager.Dispose();
        }

        private Command StopCommand()
        {
            Command command = new("stop", "Stops the continuous mode");

            command.AddAlias("exit");
            command.AddAlias("quit");

            command.SetHandler(() =>
            {
                Console.WriteLine("Stopping the continuous mode");

                isRunning = false;
            });

            return command;
        }
    }
}
