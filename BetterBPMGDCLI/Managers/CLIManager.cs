using BetterBPMGDCLI.CLICommands;
using BetterBPMGDCLI.Utils;
using System.CommandLine;

namespace BetterBPMGDCLI.Managers
{
    public class CLIManager(WorkFlowManager workFlowManager)
    {
        private readonly WorkFlowManager workFlowManager = workFlowManager;

        private readonly ResourceManager<CLIManager> resourceManager = new(Constants.CLICommandsResourceType);

        private bool isRunning = false;


        public event EventHandler? StopContinuousMode;

        public async Task RunAsync(string[] args)
        {
            StopContinuousMode += CLIManager_StopContinuousMode;

            Option<bool> continuous = new(resourceManager.GetStringArray(Constants.BoolOptionAliasesResourceKey), // enable continuous mode
                                            description: resourceManager.GetString(Constants.BoolOptionDescriptionResourceKey),
                                            getDefaultValue: () => false);

            RootCommand rootCommand =
            [
                continuous,

                new TestCommand().BuildCommand(),
                new ClearCommand().BuildCommand(),
                new StatsCommand(workFlowManager).BuildCommand(),
                new SearchLevelsByNameCommand(workFlowManager).BuildCommand(),
                new StopCommand(this, workFlowManager).BuildCommand(),
                new AddCommand(new AddProject(workFlowManager), new AddTiming(workFlowManager)).BuildCommand(),
                new SetCommand(new CurrentProject(workFlowManager)).BuildCommand(),
                new InjectCommand(new InjectExisting(workFlowManager), new InjectNew(workFlowManager)).BuildCommand(),
            ];

            rootCommand.SetHandler((continuousEnable) =>
            {
                if (continuousEnable)
                    isRunning = true;
            }, continuous);

            _ = await rootCommand.InvokeAsync(args);

            while (isRunning)
            {
                string input = Console.ReadLine() ?? string.Empty;

                _ = await rootCommand.InvokeAsync(input);
            }

            workFlowManager.Dispose();

            await Console.Out.WriteLineAsync(resourceManager.GetString(Constants.SuccessResourceKey));

            Console.ReadLine();
        }

        public void InvokeStop() => StopContinuousMode?.Invoke(this, new());

        private void CLIManager_StopContinuousMode(object? sender, EventArgs e) => isRunning = false;
    }
}
