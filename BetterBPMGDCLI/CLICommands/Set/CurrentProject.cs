using BetterBPMGDCLI.Managers;
using BetterBPMGDCLI.Utils;
using System.CommandLine;

namespace BetterBPMGDCLI.CLICommands
{
    public class CurrentProject(WorkFlowManager workFlowManager) : ICommand
    {
        private readonly WorkFlowManager workFlowManager = workFlowManager;

        private readonly ResourceManager<CurrentProject> resourceManager = new(Constants.ResourceTypes.CLICommandsStrings);

        public Command BuildCommand()
        {
            Option<string> name = new(resourceManager.GetStringArray(Constants.CLICommandsResourcesKeys.StringOptionAliases),
                                        description: resourceManager.GetString(Constants.CLICommandsResourcesKeys.StringOptionDescription))
            {
                ArgumentHelpName = Constants.StringTypeName
            };

            Command command = new(resourceManager.GetStringArray(Constants.CLICommandsResourcesKeys.CommandNameAliases)[0],  resourceManager.GetString(Constants.CLICommandsResourcesKeys.CommandDescription))
            {
                name
            };

            foreach (string alias in resourceManager.GetStringArray(Constants.CLICommandsResourcesKeys.CommandNameAliases))
                command.AddAlias(alias); //bye bye why not and cp :(

            command.SetHandler(SetProject, name);

            return command;
        }

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
