using BetterBPMGDCLI.Managers;
using BetterBPMGDCLI.Utils;
using System.CommandLine;

namespace BetterBPMGDCLI.CLICommands
{
    public class InjectExisting(WorkFlowManager workFlowManager) : ICommand
    {
        private readonly WorkFlowManager workFlowManager = workFlowManager;

        private readonly ResourceManager<InjectExisting> resourceManager = new(Constants.ResourceTypes.CLICommandsStrings);

        public Command BuildCommand()
        {
            Option<string> key = new(resourceManager.GetStringArray(Constants.CLICommandsResourcesKeys.StringOptionAliases),
                                        description: resourceManager.GetString(Constants.CLICommandsResourcesKeys.StringOptionAliases))
            {
                IsRequired = true,
                ArgumentHelpName = Constants.StringTypeName
            };

            Command command = new(resourceManager.GetStringArray(Constants.CLICommandsResourcesKeys.CommandNameAliases)[0],
                                    resourceManager.GetString(Constants.CLICommandsResourcesKeys.CommandDescription))
            {
                key,
            };

            foreach (string alias in resourceManager.GetStringArray(Constants.CLICommandsResourcesKeys.CommandNameAliases))
                command.AddAlias(alias);

            command.SetHandler(Inject, key);

            return command;
        }

        private void Inject(string key) => workFlowManager.InjectToExisting(key);
    }
}
