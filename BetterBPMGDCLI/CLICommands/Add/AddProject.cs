using BetterBPMGDCLI.CLICommands.Core;
using BetterBPMGDCLI.Managers;
using BetterBPMGDCLI.Utils;
using System.CommandLine;

namespace BetterBPMGDCLI.CLICommands
{
    public class AddProject(WorkFlowManager workFlowManager) : ICommand
    {
        private readonly WorkFlowManager workFlowManager = workFlowManager;

        private readonly ResourceManager<AddProject> resourceManager = new(Constants.ResourceTypes.CLICommands);

        public Command BuildCommand() => new CommandBuilder<AddProject>().AddOption<string>()
                                                                            .AddOption<int>()
                                                                            .AddOption<ulong>()
                                                                            .SetHandler<string, int, ulong>(CreateNewProject)
                                                                            .BuildCommand();

        private void CreateNewProject(string name, int sondId, ulong offset)
        {
            if (string.IsNullOrEmpty(name))
            {
                Console.Error.WriteLine(resourceManager.GetString(Constants.CLICommandsResourcesKeys.CanNotBeAnEmptyString));

                return;
            }

            workFlowManager.NewTimingProject(name, sondId, offset);
        }
    }
}
