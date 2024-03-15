using BetterBPMGDCLI.Managers;
using BetterBPMGDCLI.Utils;
using System.CommandLine;
using System.Text;

namespace BetterBPMGDCLI.CLICommands
{
    public class SearchLevelsByNameCommand(WorkFlowManager workFlowManager) : ICommand
    {
        private readonly WorkFlowManager workFlowManager = workFlowManager;

        private readonly ResourceManager<SearchLevelsByNameCommand> resourceManager = new(Constants.ResourceTypes.CLICommandsStrings);

        public Command BuildCommand()
        {
            Option<string> name = new(resourceManager.GetStringArray(Constants.CLICommandsResourcesKeys.StringOptionAliases),
                                        description: resourceManager.GetString(Constants.CLICommandsResourcesKeys.StringOptionDescription))
            {
                IsRequired = true,
                ArgumentHelpName = Constants.StringTypeName
            };

            Option<bool> ignoreCase = new(resourceManager.GetStringArray(Constants.CLICommandsResourcesKeys.BoolOptionAliases),
                                            description: resourceManager.GetString(Constants.CLICommandsResourcesKeys.BoolOptionDescription),
                                            getDefaultValue: () => false)
            {
                IsRequired = false
            };

            Command command = new(resourceManager.GetStringArray(Constants.CLICommandsResourcesKeys.CommandNameAliases)[0],
                                    description: resourceManager.GetString(Constants.CLICommandsResourcesKeys.CommandDescription))
            {
                name,
                ignoreCase
            };

            foreach (string alias in resourceManager.GetStringArray(Constants.CLICommandsResourcesKeys.CommandNameAliases))
                command.AddAlias(alias);

            command.SetHandler(SearchLevels, name, ignoreCase);

            return command;
        }

        private void SearchLevels(string name, bool ignoreCase)
        {
            IEnumerable<LevelPreview?> foundLevels = workFlowManager.FindLevelsByName(name, ignoreCase);

            if (!foundLevels.Any())
            {
                Console.Error.WriteLine(resourceManager.GetString(Constants.CLICommandsResourcesKeys.DoesNotExists));

                return;
            }

            foreach (LevelPreview? level in foundLevels)
                Console.WriteLine( new StringBuilder().AppendLine(level.ToString())
                                                        .AppendLine() );
        }
    }
}
