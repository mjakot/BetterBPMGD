using BetterBPMGDCLI.CLICommands.Core;
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

        private readonly ResourceManager<AddTiming> resourceManager = new(Constants.ResourceTypes.CLICommands);

        public Command BuildCommand()
            => new CommandBuilder<AddTiming>().AddOption<ulong>(true)
                                                .AddOption<double>(true)
                                                .AddOption<bool>(false, null, () => false, [])
                                                .AddOption<int>(true)
                                                .AddOption<int>(true, null, null, "0", "1", "2", "3", "4", "200", "201", "202", "203", "1334")
                                                .AddOption<string>(true, x =>
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
                                                }, null, [])
                                                .SetHandler<ulong, double, bool, int, int, string>(AddNewTiming)
                                                .BuildCommand();

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
