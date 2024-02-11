using System.CommandLine;

namespace BetterBPMGDCLI.CLI
{
    public class NewCommand(ICommand newProject, ICommand newTiming) : ICommand
    {        
        private readonly ICommand newProject = newProject;
        private readonly ICommand newTiming = newTiming;

        public Command BuildCommand()
        {
            //TODO: move all hard coded text somewhere else
            Command command = new("new", "creates new project | new timing")
            {
                newProject.BuildCommand(),
                newTiming.BuildCommand(),
            };

            command.AddAlias("n");

            command.SetHandler(() => Console.WriteLine("Specify whether to create new project or add new timing. Note: to add new timing current project must be specified"));

            return command;
        }
    }
}
