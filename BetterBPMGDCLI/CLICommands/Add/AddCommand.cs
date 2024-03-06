using System.CommandLine;

namespace BetterBPMGDCLI.CLICommands
{
    public class AddCommand(params ICommand[] newCommands) : HostCommandBase, ICommand
    {
        private readonly ICommand[] newCommands = newCommands;

        public Command BuildCommand() => BuildCommand(newCommands, ["new", "nw"], "Creates new project or timing", "Specify whether to create new project or add new timing. Note: to add a new timing current project must be specified");
    }
}
