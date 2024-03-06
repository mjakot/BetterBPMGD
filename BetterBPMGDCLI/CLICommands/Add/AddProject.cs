using BetterBPMGDCLI.Managers;
using System.CommandLine;

namespace BetterBPMGDCLI.CLICommands
{
    public class AddProject(WorkFlowManager workFlowManager) : ICommand
    {
        private readonly WorkFlowManager workFlowManager = workFlowManager;

        public Command BuildCommand()
        {
            Option<string> name = new(["--name", "-n"], description: "Specifies the name for the project") { IsRequired = true, ArgumentHelpName = "string" };
            Option<int> sondId = new(["--song", "-s"], description: "Specifies the id for the initial song of the project") { IsRequired = true, ArgumentHelpName = "int" };
            Option<ulong> offset = new(["--offset", "-o"], description: "Specifies the offset for the initial song of the project") { IsRequired = true, ArgumentHelpName = "ulong" };

            Command command = new("project", "creates new project")
            {
                name,
                sondId,
                offset
            };

            command.AddAlias("pj");
            command.AddAlias("proj");

            command.SetHandler(CreateNewProject, name, sondId, offset);

            return command;
        }

        private void CreateNewProject(string name, int sondId, ulong offset)
        {
            if (string.IsNullOrEmpty(name))
            {
                Console.Error.WriteLine("Name could not be an empty string");

                return;
            }

            workFlowManager.NewTimingProject(name, sondId, offset);
        }
    }
}
