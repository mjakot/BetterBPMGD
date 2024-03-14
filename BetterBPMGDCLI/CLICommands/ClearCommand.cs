using BetterBPMGDCLI.Managers;
using BetterBPMGDCLI.Utils;
using System.CommandLine;

namespace BetterBPMGDCLI.CLICommands
{
    public class ClearCommand : ICommand
    {
        private ResourceManager<ClearCommand> resourceManager = new(Constants.ResourceTypes.CLICommandsStrings);

        public Command BuildCommand()
        {
            Command command = new(resourceManager.GetStringArray(Constants.CLICommandsResourcesKeys.CommandNameAliases)[0], resourceManager.GetString(Constants.CLICommandsResourcesKeys.CommandDescription));

            foreach (string alias in resourceManager.GetStringArray(Constants.CLICommandsResourcesKeys.CommandNameAliases))
                command.AddAlias(alias);

            command.SetHandler(Console.Clear);

            return command;
        }
    }
}
