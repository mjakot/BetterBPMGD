using System.CommandLine;

namespace BetterBPMGDCLI.CLICommands
{
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
