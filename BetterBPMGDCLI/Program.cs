using BetterBPMGDCLI.Managers;

internal class Program
{
    private static async Task Main(string[] args)
    {
        WorkFlowManager workFlowManager = StartupManager.Startup()
        CLIManager cliManager = new(workFlowManager);

        await cliManager.RunAsync(args);
    }
}