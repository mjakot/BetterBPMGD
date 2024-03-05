using BetterBPMGDCLI.Managers;
using System.CommandLine;

namespace BetterBPMGDCLI.CLICommands
{
    /// <include file="..\..\Docs\Classes\InjectExistingDoc.xml" path="doc/type"/>
    public class InjectExisting(WorkFlowManager workFlowManager) : ICommand
    {
        private readonly WorkFlowManager workFlowManager = workFlowManager;

        /// <include file="..\..\Docs\Classes\InjectExistingDoc.xml" path="doc/method"/>
        public Command BuildCommand()
        {
            Option<string> key = new(["--key", "-k"], description: "Specifies the key of the existing level") { IsRequired = true };

            Command command = new("existing", description: "Injects timings from current project into existing level specified by the key")
            {
                key,
            };

            command.AddAlias("xng");

            command.SetHandler(Inject, key);

            return command;
        }

        private void Inject(string key) => workFlowManager.InjectToExisting(key);
    }
}
