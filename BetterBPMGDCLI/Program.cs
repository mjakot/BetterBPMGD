using BetterBPMGDCLI.Managers;

internal class Program
{
    private static async Task Main(string[] args)
    {
        WorkFlowManager workFlowManager = StartupManager.Startup();
        CLIManager cLIManager = new CLIManager(workFlowManager);

        await cLIManager.RunAsync(args);

        await Console.Out.WriteLineAsync("Press enter to exit");
        Console.ReadLine();
    }
}