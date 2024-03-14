﻿using BetterBPMGDCLI.Managers;
using BetterBPMGDCLI.Utils;
using System.CommandLine;

namespace BetterBPMGDCLI.CLICommands
{
    public class AddProject(WorkFlowManager workFlowManager) : ICommand
    {
        private readonly WorkFlowManager workFlowManager = workFlowManager;

        private readonly ResourceManager<AddProject> resourceManager = new(Constants.ResourceTypes.CLICommandsStrings);

        public Command BuildCommand()
        {
            Option<string> name = new(resourceManager.GetStringArray(Constants.CLICommandsResourcesKeys.NameOptionAliases),
                                        description: resourceManager.GetString(Constants.CLICommandsResourcesKeys.NameOptionDescription))
            {
                IsRequired = true,
                ArgumentHelpName = "string"
            };

            Option<int> sondId = new(resourceManager.GetStringArray(Constants.CLICommandsResourcesKeys.SongIDOptionAliases),
                                        description: resourceManager.GetString(Constants.CLICommandsResourcesKeys.SongIDOptionDescription))
            {
                IsRequired = true,
                ArgumentHelpName = "int"
            };

            Option<ulong> offset = new(resourceManager.GetStringArray(Constants.CLICommandsResourcesKeys.OffsetOptionAliases),
                                        description: resourceManager.GetString(Constants.CLICommandsResourcesKeys.OffsetOptionDescription))
            {
                IsRequired = true,
                ArgumentHelpName = "ulong"
            };

            Command command = new(resourceManager.GetStringArray(Constants.CLICommandsResourcesKeys.CommandNameAliases)[0],
                                    resourceManager.GetString(Constants.CLICommandsResourcesKeys.CommandDescription))
            {
                name,
                sondId,
                offset
            };

            foreach (string alias in resourceManager.GetStringArray(Constants.CLICommandsResourcesKeys.CommandNameAliases))
                command.AddAlias(alias);

            command.SetHandler(CreateNewProject, name, sondId, offset);

            return command;
        }

        private void CreateNewProject(string name, int sondId, ulong offset)
        {
            if (string.IsNullOrEmpty(name))
            {
                Console.Error.WriteLine("Name could not be an empty string");

                return;
            }

            workFlowManager.NewTimingProject(name, sondId, offset);
        }
    }
}
