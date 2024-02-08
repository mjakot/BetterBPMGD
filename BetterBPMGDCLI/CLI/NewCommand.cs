using System.CommandLine;

namespace BetterBPMGDCLI.CLI
{
    public class NewCommand : ICommand
    {
        public Command BuildCommand()
        {
            Command command = new("new", "create new project | new timing");

            command.AddOption(new Option<int>(["--type", "-t"], "Specifies the type of the new operation"));
            command.AddOption(new Option<int>(["--name", "-n"], "Specifies the name for the new operation"));

            command.SetHandler(() => null);

            return command;
        }
    }
}
