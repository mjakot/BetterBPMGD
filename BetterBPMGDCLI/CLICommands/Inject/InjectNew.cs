using BetterBPMGDCLI.Managers;
using BetterBPMGDCLI.Utils;
using System.CommandLine;

namespace BetterBPMGDCLI.CLICommands
{
    public class InjectNew(WorkFlowManager workFlowManager) : ICommand
    {
        private readonly WorkFlowManager workFlowManager = workFlowManager;

        private readonly ResourceManager<InjectNew> resourceManager = new(Constants.ResourceTypes.CLICommandsStrings);

        public Command BuildCommand()
        {
            Option<string> name = new(resourceManager.GetStringArray(Constants.CLICommandsResourcesKeys.StringOptionAliases),
                                        description: resourceManager.GetString(Constants.CLICommandsResourcesKeys.StringOptionDescription))
            {
                IsRequired = true,
                ArgumentHelpName = Constants.StringTypeName
            };

            Command command = new(resourceManager.GetStringArray(Constants.CLICommandsResourcesKeys.CommandNameAliases)[0],
                                    description: resourceManager.GetString(Constants.CLICommandsResourcesKeys.CommandDescription))
            {
                name
            };

            foreach (string alias in resourceManager.GetStringArray(Constants.CLICommandsResourcesKeys.CommandNameAliases))
                command.AddAlias(alias);

            command.SetHandler(Inject, name);

            return command;
        }

        private void Inject(string name) => workFlowManager.InjectToNew(name);
    }
}
