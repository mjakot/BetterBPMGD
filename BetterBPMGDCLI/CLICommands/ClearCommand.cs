using BetterBPMGDCLI.CLICommands.Core;
using System.CommandLine;

namespace BetterBPMGDCLI.CLICommands
{
    public class ClearCommand : ICommand
    {
        public Command BuildCommand() => new CommandBuilder<ClearCommand>().SetHandler(Console.Clear)
                                                                             .BuildCommand();
    }
}
