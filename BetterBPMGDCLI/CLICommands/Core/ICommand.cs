using System.CommandLine;

namespace BetterBPMGDCLI.CLICommands
{
    public interface ICommand
    {
        Command BuildCommand();
    }
}
