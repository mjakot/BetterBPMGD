using System.CommandLine;

namespace BetterBPMGDCLI.CLICommands
{
    public class RemoveCommand(ICommand[] removeCommands) : HostCommandBase, ICommand
    {
        private readonly ICommand[] removeCommands = removeCommands;

        public Command BuildCommand() => BuildCommand<RemoveCommand>(removeCommands);
    }
}
