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
            Option<string> name = new(["--name", "-n"], description: "Specifies the name of the levels") { IsRequired = true };
            Option<bool> ignoreCase = new(["--case", "-c", "--insensitive", "--caseinsensitive", "--caseInsensitive", "--case-insensitive", "-i", "--ignoreCase", "--ignorecase", "--ignore-case"], description: "Specifies whether search should be case insensitive", getDefaultValue: () => false) { IsRequired = false };

            name.ArgumentHelpName = "string";

            Command command = new("searchL", description: "Searches levels by name. Returns collection of levels that match the specified name.")
            {
                name,
                ignoreCase
            };

            command.AddAlias("searchLevels");
            command.AddAlias("searchlevels");
            command.AddAlias("search-levels");
            command.AddAlias("search-l");
            command.AddAlias("searchl");
            command.AddAlias("srchl");
            command.AddAlias("srch-l");
            command.AddAlias("srchL");

            command.SetHandler(SearchLevels, name, ignoreCase);

            return command;
        }

        private void SearchLevels(string name, bool ignoreCase)
        {
            IEnumerable<LevelPreview?> foundLevels = workFlowManager.FindLevelsByName(name, ignoreCase);

            if (!foundLevels.Any())
            {
                Console.Error.WriteLine("No levels found");

                return;
            }

            foreach (LevelPreview? level in foundLevels)
                Console.WriteLine( new StringBuilder().AppendLine(level.ToString())
                                                        .AppendLine() );
        }
    }
}
