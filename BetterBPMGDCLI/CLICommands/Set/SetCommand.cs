using System.CommandLine;

namespace BetterBPMGDCLI.CLICommands
{
    public class SetCommand(params ICommand[] setCommands) : HostCommandBase, ICommand
    {
        private readonly ICommand[] setCommands = setCommands;

        public Command BuildCommand() => BuildCommand<SetCommand>(setCommands);
    }
}
