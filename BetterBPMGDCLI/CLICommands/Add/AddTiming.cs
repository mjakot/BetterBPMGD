using BetterBPMGDCLI.Managers;
using BetterBPMGDCLI.Models.Level;
using BetterBPMGDCLI.Utils;
using Common;
using System.CommandLine;

namespace BetterBPMGDCLI.CLICommands
{
    public class AddTiming(WorkFlowManager workFlowManager) : ICommand
    {
        private readonly WorkFlowManager workFlowManager = workFlowManager;

        private readonly ResourceManager<AddTiming> resourceManager = new(Constants.ResourceTypes.CLICommandsStrings);

        public Command BuildCommand()
        {
            Option<ulong> offset = new(resourceManager.GetStringArray(Constants.CLICommandsResourcesKeys.OffsetOptionAliases),
                                        description: resourceManager.GetString(Constants.CLICommandsResourcesKeys.OffsetOptionDescription))
            {
                IsRequired = true,
                ArgumentHelpName = "ulong"
            };

            Option<double> bpm = new(resourceManager.GetStringArray(Constants.CLICommandsResourcesKeys.BPMOptionAliases),
                                        description: resourceManager.GetString(Constants.CLICommandsResourcesKeys.BPMOptionDescription))
            {
                IsRequired = true,
                ArgumentHelpName = "double"
            };

            Option<bool> subdivideBeats = new(resourceManager.GetStringArray(Constants.CLICommandsResourcesKeys.BoolOptionAliases),
                                                description: resourceManager.GetString(Constants.CLICommandsResourcesKeys.BoolOptionDescription))
            {
                IsRequired = true
            };

            Option<int> beatSubdivision = new(resourceManager.GetStringArray(Constants.CLICommandsResourcesKeys.BeatSubdivisionOptionAliases),
                                                description: resourceManager.GetString(Constants.CLICommandsResourcesKeys.BeatSubdivisionOptionDescription))
            {
                IsRequired = true,
                ArgumentHelpName = "int"
            };

            Option<int> speed = new Option<int>(resourceManager.GetStringArray(Constants.CLICommandsResourcesKeys.SpeedOptionAliases),
                                                    description: resourceManager.GetString(Constants.CLICommandsResourcesKeys.SpeedOptionDescription))
            {
                IsRequired = true,
                ArgumentHelpName = "int"
            }.FromAmong("0", "1", "2", "3", "4", "200", "201", "202", "203", "1334");

            Option<string> colorPattern = new(resourceManager.GetStringArray(Constants.CLICommandsResourcesKeys.ColorPatternOptionAliases),
                                                description: resourceManager.GetString(Constants.CLICommandsResourcesKeys.ColorPatternOptionDescription))
            {
                IsRequired = true,
                ArgumentHelpName = "string"
            };

            colorPattern.AddValidator(x =>
            {
                string? value = x.GetValueOrDefault<string>();

                if (string.IsNullOrEmpty(value))
                {
                    x.ErrorMessage = resourceManager.GetString(Constants.CLICommandsResourcesKeys.CanNotBeAnEmptyString);

                    return;
                }

                if (value.Length > 3)
                {
                    x.ErrorMessage = resourceManager.GetString(Constants.CLICommandsResourcesKeys.CanNotBeLongerThan);

                    return;
                }

                if (!value.All(c => GuidelineColors.AvailableColors.Contains(c)))
                {
                    x.ErrorMessage = resourceManager.GetString(Constants.CLICommandsResourcesKeys.CanNotInclude);

                    return;
                }
            });

            Command command = new(resourceManager.GetStringArray(Constants.CLICommandsResourcesKeys.CommandNameAliases)[0],
                                    resourceManager.GetString(Constants.CLICommandsResourcesKeys.CommandDescription))
            {
                offset,
                bpm,
                subdivideBeats,
                beatSubdivision,
                speed,
                colorPattern
            };

            foreach (string alias in resourceManager.GetStringArray(Constants.CLICommandsResourcesKeys.CommandNameAliases))
                command.AddAlias(alias);

            command.SetHandler(AddNewTiming, offset, bpm, subdivideBeats, beatSubdivision, speed, colorPattern);

            return command;
        }

        private void AddNewTiming(ulong offset, double bpm, bool subdivideBeats, int beatSubdivision, int speed, string colorPattern)
        {
            if (workFlowManager.CurrentTimingProject.Name == string.Empty)
            {
                Console.WriteLine(resourceManager.GetString(Constants.CLICommandsResourcesKeys.CurrentProjectMustBeSpecified));

                return;
            }

            SpeedPortalTypes type = speed switch
            {
                200 or 0 => SpeedPortalTypes.HALFSPEED,
                201 or 1 => SpeedPortalTypes.NORMAL,
                202 or 2 => SpeedPortalTypes.DOUBLE,
                203 or 3 => SpeedPortalTypes.TRIPLE,
                1334 or 4 => SpeedPortalTypes.QUADRUPLE,
                _ => SpeedPortalTypes.HALFSPEED
            };

            workFlowManager.CurrentTimingProject.AddTiming(new(offset, bpm, subdivideBeats, beatSubdivision, type, colorPattern));
        }
    }
}
