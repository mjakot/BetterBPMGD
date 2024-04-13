using BetterBPMGDCLI.Managers;

namespace BetterBPMGDCLI
{
    public static class Program
    {
        public static WorkFlowManager? WorkFlowManager { get; private set; }
        public static CLIManager? CLIManager { get; private set; }

        public static async Task Main(string[] args)
        {
            WorkFlowManager = StartupManager.Startup();
            CLIManager = new(WorkFlowManager);

            if (args[0] != "suppress")
                await CLIManager.RunAsync(args);
        }
    }
}