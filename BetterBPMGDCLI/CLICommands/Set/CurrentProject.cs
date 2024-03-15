using BetterBPMGDCLI.CLICommands.Core;
using BetterBPMGDCLI.Managers;
using BetterBPMGDCLI.Utils;
using System.CommandLine;

namespace BetterBPMGDCLI.CLICommands
{
    public class CurrentProject(WorkFlowManager workFlowManager) : ICommand
    {
        private readonly WorkFlowManager workFlowManager = workFlowManager;

        private readonly ResourceManager<CurrentProject> resourceManager = new(Constants.ResourceTypes.CLICommands);

        public Command BuildCommand() => new CommandBuilder<CurrentProject>().AddOption<string>(true) // name
                                                                                .SetHandler<string>(SetProject)
                                                                                .BuildCommand(); //bye bye why not and cp :(, farewell bulky command declaration :(((

        private void SetProject(string name)
        {
            if (!Directory.Exists(Path.Combine(workFlowManager.ConfigManager.PathSettings.TimingProjectsFolderPath, name)))
            {
                Console.WriteLine(resourceManager.GetString(Constants.CLICommandsResourcesKeys.DoesNotExists));

                return;
            }

            workFlowManager.ReadExistingTimingProject(name);
        }
    }
}
