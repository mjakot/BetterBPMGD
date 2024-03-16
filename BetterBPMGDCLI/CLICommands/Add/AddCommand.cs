using System.CommandLine;

namespace BetterBPMGDCLI.CLICommands
{
    public class AddCommand(params ICommand[] newCommands) : HostCommandBase, ICommand
    {
        private readonly ICommand[] newCommands = newCommands;

        public Command BuildCommand() => BuildCommand<AddCommand>(newCommands);
    }
}
