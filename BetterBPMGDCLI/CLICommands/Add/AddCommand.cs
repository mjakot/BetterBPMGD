using System.CommandLine;

namespace BetterBPMGDCLI.CLICommands
{
    /// <include file='..\..\Docs\Classes\AddCommandDoc.xml' path='doc/type'/>
    public class AddCommand(params ICommand[] newCommands) : HostCommandBase, ICommand
    {
        private readonly ICommand[] newCommands = newCommands;

        public Command BuildCommand() => BuildCommand<AddCommand>(newCommands);
    }
}
