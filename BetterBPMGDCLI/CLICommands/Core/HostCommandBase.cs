using BetterBPMGDCLI.CLICommands.Core;
using System.CommandLine;

namespace BetterBPMGDCLI.CLICommands
{
    /// <include file="..\..\Docs\Classes\HostCommandBaseDoc.xml" path="doc/type"/>
    public abstract class HostCommandBase
    {
        /// <include file="..\..\Docs\Classes\HostCommandBaseDoc.xml" path="doc/method[@name='BuildCommand']"/>
		protected static Command BuildCommand<T>(ICommand[] commands) where T : class, ICommand
        {
            Command hostCommand = new CommandBuilder<T>().BuildCommand();

            foreach (ICommand command in commands)
                hostCommand.AddCommand(command.BuildCommand());

            return hostCommand;
        }
    }
}
