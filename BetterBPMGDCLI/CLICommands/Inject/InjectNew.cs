using BetterBPMGDCLI.Managers;
using System.CommandLine;

namespace BetterBPMGDCLI.CLICommands
{
    public class InjectNew(WorkFlowManager workFlowManager) : ICommand
    {
        private readonly WorkFlowManager workFlowManager = workFlowManager;

        public Command BuildCommand()
        {
            Option<string> name = new(["--name", "-n"], description: "Specifies the name for the level") { IsRequired = true, ArgumentHelpName = "string" };

            Command command = new("new", description: "Creates new level and injects timings into it from current project")
            {
                name
            };

            command.AddAlias("nw");

            command.SetHandler(Inject, name);

            return command;
        }

        private void Inject(string name) => workFlowManager.InjectToNew(name);
    }
}
