using System.CommandLine;

namespace BetterBPMGDCLI.CLICommands
{
    public class TestCommand : ICommand
    {
        public Command BuildCommand()
        {
            Command command = new("bruh", "playing around");

            command.SetHandler(() => Console.WriteLine("Umm what the actual fuck are you doing in my house?"));

            return command;
        }
    }
}
