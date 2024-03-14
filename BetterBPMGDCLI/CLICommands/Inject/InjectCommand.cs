using System.CommandLine;

namespace BetterBPMGDCLI.CLICommands
{
    public class InjectCommand(params ICommand[] injectCommands) : HostCommandBase, ICommand
    {
        private readonly ICommand[] injectCommands = injectCommands;

        public Command BuildCommand() => BuildCommand<InjectCommand>(injectCommands);
    }
}
