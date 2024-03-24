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

        public static void ConsoleError<T>(string errorKey, int errorIndex = 0)
        {
            ResourceManager<T> resourceManager = new(Constants.CLICommandsResourceType);

            ConsoleMessage(resourceManager.GetString(CalculateResourceKey(errorKey, errorIndex)), ConsoleMessageTypes.Error);
        }

        public static void ConsoleSuccess<T>(string successKey, int successIndex = 0)
        {
            ResourceManager<T> resourceManager = new(Constants.CLICommandsResourceType);

            ConsoleMessage(resourceManager.GetString(CalculateResourceKey(successKey, successIndex)), ConsoleMessageTypes.Success);
        }

        public static void ConsoleMessage<T>(string messageKey, int messageIndex = 0)
        {
            ResourceManager<T> resourceManager = new(Constants.CLICommandsResourceType);

            ConsoleMessage(resourceManager.GetString(CalculateResourceKey(messageKey, messageIndex)), ConsoleMessageTypes.Message);
        }

        public static void ConsoleMessage(string message, ConsoleMessageTypes messageType)
        {
            ConsoleColor color = messageType switch
            {
                ConsoleMessageTypes.Error => ConsoleColor.Red,
                ConsoleMessageTypes.Success => ConsoleColor.Green,
                ConsoleMessageTypes.Message => ConsoleColor.White,
                _ => ConsoleColor.Gray,
            };

            Console.ForegroundColor = color;

            if (messageType == ConsoleMessageTypes.Error)
                Console.Error.WriteLine(message);
            else
                Console.WriteLine(message);

            Console.ForegroundColor = ConsoleColor.Gray;
        }

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
                new SetCommand(new SetCurrentProject(workFlowManager)).BuildCommand(),
                new InjectCommand(new InjectExisting(workFlowManager), new InjectNew(workFlowManager)).BuildCommand(),
                new RemoveCommand(new RemoveTiming(workFlowManager), new RemoveProject(workFlowManager)).BuildCommand()
            ];

            rootCommand.SetHandler((continuousEnable) =>
            {
                if (continuousEnable)
                    isRunning = true;
            }, continuous);

            _ = await rootCommand.InvokeAsync(args);

            while (isRunning)
            {
                Console.Write("-> ");

                string input = Console.ReadLine() ?? string.Empty;

                _ = await rootCommand.InvokeAsync(input);
            }

            workFlowManager.Dispose();

            await Console.Out.WriteLineAsync(resourceManager.GetString(Constants.SuccessResourceKey));

            Console.ReadLine();
        }

        public void InvokeStop() => StopContinuousMode?.Invoke(this, new());

        private static string CalculateResourceKey(string resourceKey, int keyIndex) => keyIndex == 0 ? resourceKey : resourceKey + keyIndex;

        private void CLIManager_StopContinuousMode(object? sender, EventArgs e) => isRunning = false;
    }
}
