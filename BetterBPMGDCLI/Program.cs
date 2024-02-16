using BetterBPMGDCLI.Managers;
using BetterBPMGDCLI.Models.Settings;

internal class Program
{
    private static async Task Main(string[] args)
    {
        WorkFlowManager workFlowManager = StartupManager.Startup(new PathSettings());
        CLIManager cLIManager = new CLIManager(workFlowManager);

        await cLIManager.RunAsync(args);
    }
}