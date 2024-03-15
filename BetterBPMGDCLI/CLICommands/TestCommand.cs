using BetterBPMGDCLI.CLICommands.Core;
using System.CommandLine;

namespace BetterBPMGDCLI.CLICommands
{
    public class TestCommand : ICommand
    {
        public Command BuildCommand() => new CommandBuilder<TestCommand>().BuildCommand();
    }
}
