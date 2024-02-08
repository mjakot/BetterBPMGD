using System.CommandLine;

namespace BetterBPMGDCLI.CLI
{
    public interface ICommand
    {
        Command BuildCommand();
    }
}
