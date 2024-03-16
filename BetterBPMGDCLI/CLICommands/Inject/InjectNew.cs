using BetterBPMGDCLI.CLICommands.Core;
using BetterBPMGDCLI.Managers;
using System.CommandLine;

namespace BetterBPMGDCLI.CLICommands
{
    /// <include file="..\..\Docs\Classes\InjectNewDoc.xml" path="doc/type"/>
    public class InjectNew(WorkFlowManager workFlowManager) : ICommand
    {
        private readonly WorkFlowManager workFlowManager = workFlowManager;

        /// <include file="..\..\Docs\Classes\InjectExistingDoc.xml" path="doc/method"/>
		public Command BuildCommand() => new CommandBuilder<InjectNew>().AddOption<string>() // name
                                                                            .SetHandler<string>(Inject)
                                                                            .BuildCommand();

        private void Inject(string name) => workFlowManager.InjectToNew(name);
    }
}
