using System.CommandLine;

namespace BetterBPMGDCLI.CLICommands
{
    /// <include file='..\..\Docs\Classes\SetCommandDoc.xml' path='doc/type'/>
    public class SetCommand(params ICommand[] setCommands) : HostCommandBase, ICommand
    {
        private readonly ICommand[] setCommands = setCommands;

        public Command BuildCommand() => BuildCommand<SetCommand>(setCommands);
    }
}
