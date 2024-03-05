using System.CommandLine;

namespace BetterBPMGDCLI.CLICommands
{
    ///<include file="../Docs/Classes/ClearCommandDoc.xml" path="doc/type"/>
    public class ClearCommand : ICommand
    {
        public Command BuildCommand()
        {
            Command command = new("clear", "Clears command line");

            command.AddAlias("cls");

            command.SetHandler(Console.Clear);

            return command;
        }
    }
}
