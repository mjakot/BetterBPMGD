using System.CommandLine;

namespace BetterBPMGDCLI.CLI
{
    public class SetCommand(ICommand setCurrentProject) : ICommand
    {
        private readonly ICommand setCurrentProject = setCurrentProject;

        public Command BuildCommand()
        {
            Command command = new("set", "Sets values")
            {
                setCurrentProject.BuildCommand()
            };

            command.AddAlias("s");

            command.SetHandler(() => Console.WriteLine("Specify what value to change"));

            return command;
        }
    }
}
