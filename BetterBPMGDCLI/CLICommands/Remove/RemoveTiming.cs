using BetterBPMGDCLI.Managers;
using BetterBPMGDCLI.Utils;
using System.CommandLine;

namespace BetterBPMGDCLI.CLICommands
{
    public class RemoveTiming(WorkFlowManager workFlowManager) : ICommand
    {
        private readonly WorkFlowManager workFlowManager = workFlowManager;

        public Command BuildCommand() => new CommandBuilder<RemoveTiming>().AddOption<int>()
                                                                             .SetHandler<int>(Remove)
                                                                             .BuildCommand();

        private void Remove(int id)
        {
            workFlowManager.CurrentTimingProject.RemoveTiming(id);

            CLIManager.ConsoleSuccess<RemoveTiming>(Constants.SuccessResourceKey);
        }
    }
}
