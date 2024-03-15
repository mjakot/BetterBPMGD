using BetterBPMGDCLI.CLICommands.Core;
using BetterBPMGDCLI.Managers;
using System.CommandLine;

namespace BetterBPMGDCLI.CLICommands
{
    public class InjectNew(WorkFlowManager workFlowManager) : ICommand
    {
        private readonly WorkFlowManager workFlowManager = workFlowManager;

        public Command BuildCommand() => new CommandBuilder<InjectNew>().AddOption<string>() // name
                                                                            .SetHandler<string>(Inject)
                                                                            .BuildCommand();

        private void Inject(string name) => workFlowManager.InjectToNew(name);
    }
}
