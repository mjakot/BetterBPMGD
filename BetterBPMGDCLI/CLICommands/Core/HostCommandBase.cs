using BetterBPMGDCLI.CLICommands.Core;
using System.CommandLine;

namespace BetterBPMGDCLI.CLICommands
{
    public abstract class HostCommandBase
    {
        protected static Command BuildCommand<T>(ICommand[] commands) where T : class, ICommand
        {
            Command hostCommand = new CommandBuilder<T>().BuildCommand();

            foreach (ICommand command in commands)
                hostCommand.AddCommand(command.BuildCommand());

            return hostCommand;
        }
    }
}
