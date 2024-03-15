using BetterBPMGDCLI.CLICommands.Core;
using BetterBPMGDCLI.Managers;
using BetterBPMGDCLI.Utils;
using System.CommandLine;

namespace BetterBPMGDCLI.CLICommands
{
    public class InjectExisting(WorkFlowManager workFlowManager) : ICommand
    {
        private readonly WorkFlowManager workFlowManager = workFlowManager;

        public Command BuildCommand() => new CommandBuilder<InjectExisting>().AddOption<string>()
                                                                                .SetHandler<string>(Inject)
                                                                                .BuildCommand();

        private void Inject(string key) => workFlowManager.InjectToExisting(key);
    }
}
