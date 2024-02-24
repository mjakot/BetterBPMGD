using BetterBPMGDCLI.Managers;
using System.CommandLine;

namespace BetterBPMGDCLI.CLICommands
{
    public class SearchLevelsByNameCommand(WorkFlowManager workFlowManager) : ICommand
    {
        private readonly WorkFlowManager workFlowManager = workFlowManager;

        public Command BuildCommand()
        {
            Option<string> name = new(["--name", "-n"], description: "Specifies the name of the levels");

            Command command = new("search", description: "Searches levels by name. Returns collection of levels with name specified.")
            {
                name
            };

            //command.AddAlias("searchLevels");
            //command.AddAlias("searchlevels");
            command.AddAlias("search-levels");

            command.SetHandler(SearchLevels, name);

            return command;
        }

        private void SearchLevels(string name)
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
                Console.WriteLine(index.ToString() + " - " + level.ToString());

                index++;
            }
        }
    }
}
