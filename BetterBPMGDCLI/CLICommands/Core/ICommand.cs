using System.CommandLine;

namespace BetterBPMGDCLI.CLICommands
{
    /// <include file="..\..\Docs\Classes\ICommandDoc.xml" path="doc/type"/>
    public interface ICommand
    {
        /// <include file="..\..\Docs\Classes\ICommandDoc.xml" path="doc/method"/>
        Command BuildCommand();
    }
}
