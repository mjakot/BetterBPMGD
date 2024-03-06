using System.CommandLine;

namespace BetterBPMGDCLI.CLICommands
{
    public class InjectCommand(params ICommand[] injectCommands) : HostCommandBase, ICommand
    {
        private readonly ICommand[] injectCommands = injectCommands;

        public Command BuildCommand() => BuildCommand(injectCommands, ["inject", "inj"], "Injects timings from current project into a new or already existing local level", "Specify whether to inject into new or already existing local level. Note: to inject into existing local level you must specify its key. Use \"search-levels\" command to find levels key. Type \"schl -h\" to learn more");
    }
}
