using BetterBPMGDCLI.Managers;
using System.CommandLine;

namespace BetterBPMGDCLI.CLI
{
    public class NewProject(WorkFlowManager workFlowManager) : ICommand
    {
        private readonly WorkFlowManager workFlowManager = workFlowManager;

        public Command BuildCommand()
        {
            Option<string> name = new(["--name", "-n"], description: "Specifies the name for the project") { IsRequired = true };
            Option<int> sondId = new(["--song", "-s"], description: "Specifies the id for the initial song of the project") { IsRequired = true };
            Option<ulong> offset = new(["--offset", "-o"], description: "Specifies the offset for the initial song of the project") { IsRequired = true };

            Command command = new("project", "creates new project")
            {
                name,
                sondId,
                offset
            };

            command.AddAlias("p");
            command.AddAlias("proj");

            command.SetHandler(CreateNewProject, name, sondId, offset);

            return command;
        }

        private void CreateNewProject(string name, int sondId, ulong offset) => workFlowManager.NewTimingProject(name, sondId, offset);
    }
}
