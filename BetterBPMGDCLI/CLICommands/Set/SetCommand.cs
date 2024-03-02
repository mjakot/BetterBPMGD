using System.CommandLine;

namespace BetterBPMGDCLI.CLICommands
{
    public class SetCommand(params ICommand[] setCommands) : ICommand
    {
        private readonly ICommand[] setCommands = setCommands;

        public Command BuildCommand()
        {
            Command command = new("set", "Sets values");

            foreach (var cmd in setCommands)
                command.Add(cmd.BuildCommand());

            command.AddAlias("st");

            command.SetHandler(() => Console.WriteLine("Specify what value to change"));

            return command;
        }
    }
}
