using BetterBPMGDCLI.Managers;
using BetterBPMGDCLI.Utils;
using System.CommandLine;

namespace BetterBPMGDCLI.CLICommands.Remove
{
    public class RemoveProject(WorkFlowManager workFlowManager) : ICommand
    {
        private readonly WorkFlowManager workFlowManager = workFlowManager;

        public Command BuildCommand() => new CommandBuilder<RemoveProject>().AddOption<string>()
                                                                                .SetHandler<string>(Remove)
                                                                                .BuildCommand();

        private void Remove(string name)
        {
            workFlowManager.RemoveTimingProject(name);

            CLIManager.ConsoleSuccess<RemoveProject>(Constants.SuccessResourceKey);
        }
    }
}
