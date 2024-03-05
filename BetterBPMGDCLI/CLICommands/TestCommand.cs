using System.CommandLine;

namespace BetterBPMGDCLI.CLICommands
{
    ///<include file='../Docs/Classes/TestCommandDoc.xml' path='doc/type'/>
    public class TestCommand : ICommand
    {
        ///<include file='../Docs/Classes/TestCommandDoc.xml' path='doc/method'/>
        public Command BuildCommand()
        {
            Command command = new("bruh", "playing around");

            command.SetHandler(() => Console.WriteLine("Umm what the actual fuck are you doing in my house?"));

            return command;
        }
    }
}
