using BetterBPMGDCLI.Managers;
using System.CommandLine;

namespace BetterBPMGDCLI.CLICommands
{
    public class SetCurrentProjectCommand(WorkFlowManager workFlowManager) : ICommand
    {
        private readonly WorkFlowManager workFlowManager = workFlowManager;

        public Command BuildCommand()
        {
            Option<string> name = new(["--name", "-n"], description: "Specifies the name of the project");

            Command command = new("proj", "Specifies the current timing project")
            {
                name
            };

            command.AddAlias("currentproject");
            command.AddAlias("current-project");
            command.AddAlias("currproj"); // aint no way im adding "cp" as alias

            command.SetHandler(SetCurrentProject, name);

            return command;
        }

        private void SetCurrentProject(string name)
        {
            if (!Directory.Exists(Path.Combine(workFlowManager.ConfigManager.PathSettings.TimingProjectsFolderPath, name)))
            {
                Console.WriteLine("Project with this name does not exist");

                return;
            }

            workFlowManager.ReadExistingTimingProject(name);
        }
    }
}
