using BetterBPMGDCLI.Managers;
using System.CommandLine;

namespace BetterBPMGDCLI.CLICommands
{
    /// <include file="..\..\Docs\Classes\InjectNewDoc.xml" path="doc/type"/>
    public class InjectNew(WorkFlowManager workFlowManager) : ICommand
    {
        private readonly WorkFlowManager workFlowManager = workFlowManager;

        /// <include file="..\..\Docs\Classes\InjectExistingDoc.xml" path="doc/method"/>
        public Command BuildCommand()
        {
            Option<string> name = new(["--name", "-n"], description: "Specifies the name for the level") { IsRequired = true};

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
