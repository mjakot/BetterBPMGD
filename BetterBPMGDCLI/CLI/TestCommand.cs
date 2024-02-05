using System.CommandLine;

namespace BetterBPMGDCLI.CLI
{
    public class TestCommand
    {
        public Command BuildCommand()
        {
            Command command = new("bruh", "playing around");

            command.SetHandler(() => Console.WriteLine("Umm what the actual fuck are you doing in my house?"));

            return command;
        }
    }
}
