using BetterBPMGDCLI.Managers;
using BetterBPMGDCLI.Utils;
using System.CommandLine;
using System.Text;

namespace BetterBPMGDCLI.CLICommands
{
    ///<include file='..\Docs\Classes\SearchLevelsByNameCommandDoc.xml' path='doc/type'/>
    public class SearchLevelsByNameCommand(WorkFlowManager workFlowManager) : ICommand
    {
        private readonly WorkFlowManager workFlowManager = workFlowManager;

        private readonly ResourceManager<SearchLevelsByNameCommand> resourceManager = new(Constants.CLICommandsResourceType);

        public Command BuildCommand() => new CommandBuilder<SearchLevelsByNameCommand>().AddOption<string>(true)                           // name
                                                                                            .AddOption<bool>(false, null, () => false, []) // case insensitive
                                                                                            .SetHandler<string, bool>(SearchLevels)
                                                                                            .BuildCommand();

        private void SearchLevels(string name, bool ignoreCase)
        {
            IEnumerable<LevelPreview?> foundLevels = workFlowManager.FindLevelsByName(name, ignoreCase);

            if (!foundLevels.Any())
            {
                Console.Error.WriteLine(resourceManager.GetString(Constants.DoesNotExistsResourceKey));

                return;
            }

            foreach (LevelPreview? level in foundLevels)
                Console.WriteLine(new StringBuilder().AppendLine(level.ToString())
                                                        .AppendLine());
        }
    }
}
