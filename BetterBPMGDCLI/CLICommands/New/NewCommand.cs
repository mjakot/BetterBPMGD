using System.CommandLine;

namespace BetterBPMGDCLI.CLICommands
{
    public class NewCommand(params ICommand[] newCommands) : ICommand
    {
        private readonly ICommand[] newCommands = newCommands;

        public Command BuildCommand()
        {
            //TODO: move all hard coded text somewhere else
            Command command = new("new", "Creates new project | new timing");

            foreach (ICommand cmd in newCommands)
                command.Add(cmd.BuildCommand());

            command.AddAlias("nw");

            command.SetHandler(() => Console.WriteLine("Specify whether to create new project or add new timing. Note: to add new timing current project must be specified"));

            return command;
        }
    }
}
