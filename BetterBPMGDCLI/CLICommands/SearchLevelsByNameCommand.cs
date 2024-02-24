using BetterBPMGDCLI.Managers;
using System.CommandLine;
using System.Text;

namespace BetterBPMGDCLI.CLICommands
{
    public class SearchLevelsByNameCommand(WorkFlowManager workFlowManager) : ICommand
    {
        private readonly WorkFlowManager workFlowManager = workFlowManager;

        public Command BuildCommand()
        {
            Option<string> name = new(["--name", "-n"], description: "Specifies the name of the levels");
            Option<string> ingnoreCase = new(["--case", "-c", "--insensitive", "-i", "--ignoreCase", "--ignorecase", "--ignore-case"], description: "Specifies whether search should be case insensitive");

            Command command = new("search", description: "Searches levels by name. Returns collection of levels with name specified.")
            {
                name,
                ingnoreCase
            };

            command.AddAlias("searchLevels");
            command.AddAlias("searchlevels");
            command.AddAlias("search-levels");

            command.SetHandler(SearchLevels, name, ingnoreCase);

            return command;
        }

        private void SearchLevels(string name, bool ingnoreCase)
        {
            IEnumerable<LevelPreview?> foundLevels = workFlowManager.FindLevelsByName(name);

            if (!foundLevels.Any())
            {
                Console.Error.WriteLine("No levels found");

                return;
            }

            int index = 0;

            foreach (LevelPreview? level in foundLevels)
            {
                Console.WriteLine( new StringBuilder().Append(index.ToString())
                                                        .AppendLine("  --")
                                                        .AppendLine(level.ToString())
                                                        .AppendLine() );

                index++;
            }
        }
    }
}
