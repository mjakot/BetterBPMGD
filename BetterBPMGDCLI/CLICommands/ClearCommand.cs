using BetterBPMGDCLI.CLICommands.Core;
using System.CommandLine;

namespace BetterBPMGDCLI.CLICommands
{
    ///<include file="../Docs/Classes/ClearCommandDoc.xml" path="doc/type"/>
    public class ClearCommand : ICommand
    {
        public Command BuildCommand() => new CommandBuilder<ClearCommand>().SetHandler(Console.Clear)
                                                                             .BuildCommand();
    }
}
