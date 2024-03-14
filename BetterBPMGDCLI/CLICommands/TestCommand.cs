using BetterBPMGDCLI.Managers;
using BetterBPMGDCLI.Utils;
using System.CommandLine;

namespace BetterBPMGDCLI.CLICommands
{
    public class TestCommand : ICommand
    {
        private ResourceManager<TestCommand> resourceManager = new(Constants.ResourceTypes.CLICommandsStrings);

        public Command BuildCommand()
        {
            Command command = new(resourceManager.GetStringArray(Constants.CLICommandsResourcesKeys.CommandNameAliases)[0],
                                    resourceManager.GetString(Constants.CLICommandsResourcesKeys.CommandDescription));

            command.SetHandler(() => Console.WriteLine(resourceManager.GetString(Constants.CLICommandsResourcesKeys.DefaultMessage)));

            return command;
        }
    }
}
