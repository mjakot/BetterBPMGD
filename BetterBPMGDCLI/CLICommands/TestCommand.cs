using BetterBPMGDCLI.CLICommands.Core;
using System.CommandLine;

namespace BetterBPMGDCLI.CLICommands
{
    ///<include file='../Docs/Classes/TestCommandDoc.xml' path='doc/type'/>
    public class TestCommand : ICommand
    {
        ///<include file='../Docs/Classes/TestCommandDoc.xml' path='doc/method'/>
		public Command BuildCommand() => new CommandBuilder<TestCommand>().BuildCommand();
    }
}
