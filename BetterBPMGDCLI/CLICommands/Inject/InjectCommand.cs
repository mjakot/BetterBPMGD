using System.CommandLine;

namespace BetterBPMGDCLI.CLICommands
{
    /// <include file='..\..\Docs\Classes\InjectCommandDoc.xml' path='doc/type'/>
    public class InjectCommand(params ICommand[] injectCommands) : HostCommandBase, ICommand
    {
        private readonly ICommand[] injectCommands = injectCommands;

        public Command BuildCommand() => BuildCommand<InjectCommand>(injectCommands);
    }
}
