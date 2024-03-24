using BetterBPMGDCLI.Managers;
using BetterBPMGDCLI.Utils;
using System.CommandLine;

namespace BetterBPMGDCLI.CLICommands
{
    /// <include file='..\..\Docs\Classes\InjectExistingDoc.xml' path='doc/type'/>
    public class InjectExisting(WorkFlowManager workFlowManager) : ICommand
    {
        private readonly WorkFlowManager workFlowManager = workFlowManager;
		
		public Command BuildCommand() => new CommandBuilder<InjectExisting>().AddOption<string>() // key
                                                                                .SetHandler<string>(Inject)
                                                                                .BuildCommand();

        private void Inject(string key)
        {
            workFlowManager.InjectToExisting(key);

            CLIManager.ConsoleSuccess<InjectExisting>(Constants.SuccessResourceKey);
        }
    }
}
