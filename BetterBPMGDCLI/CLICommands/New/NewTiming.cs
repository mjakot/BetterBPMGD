using BetterBPMGDCLI.Managers;
using Common;
using System.CommandLine;

namespace BetterBPMGDCLI.CLICommands
{
    public class NewTiming(WorkFlowManager workFlowManager) : ICommand
    {
        private readonly WorkFlowManager workFlowManager = workFlowManager;

        public Command BuildCommand()
        {
            Option<ulong> offset = new(["--offset", "-o"], description: "Specifies offset for the timing") { IsRequired = true, ArgumentHelpName = "ulong" };
            Option<double> bpm = new(["--bpm", "-b"], description: "Specifies bpm for the timing") { IsRequired = true, ArgumentHelpName = "double" };
            Option<bool> subdivideBeats = new(["--subdivide", "-d"], description: "Specifies whether to subdivide beats") { IsRequired = true };
            Option<int> beatSubdivision = new(["--subdivision", "-n"], description: "Specifies beat subdivision for the timing") { IsRequired = true, ArgumentHelpName = "int" };
            Option<int> speed = new Option<int>(["--speed", "-s"], description: "Specifies speed for the timing. Available speeds: 0 - HALFSPEED, 1 - NORMAL SPEED, 2 - DOUBLE SPEED, 3 - TRPLE SPEED, 4 - QUADRUPLE SPEED") { IsRequired = true, ArgumentHelpName = "int" }.FromAmong("0 -> HALFSPEED", "1 -> NORMAL SPEED", "2 -> DOUBLE SPEED", "3 -> TRPLE SPEED", "4 -> QUADRUPLE SPEED", "200", "201", "202", "203", "1334");
            Option<string> colorPatern = new(["--colors", "-c"], description: "Specifies color pattern for the guidelines. Available colors: o - orange, g - green, y - yellow, n - none. Pattern can not be longer than 3 symbols. Example: ogo (orange - green - orange)") { IsRequired = true, ArgumentHelpName = "string" };

            colorPatern.AddValidator(x =>
            {
                string? value = x.GetValueOrDefault<string>();

                if (string.IsNullOrEmpty(value))
                {
                    x.ErrorMessage = "Color patter can not be an empty string";

                    return;
                }

                if (value.Length > 3)
                {
                    x.ErrorMessage = "Color patter can not be longer than 3 characters";

                    return;
                }

                if (!value.All(c => new char[] { 'o', 'g', 'y', 'n' }.Contains(c)))
                {
                    x.ErrorMessage = "Color patter can not be any other character that o, g, y and n";
                }
            });

            Command command = new("timing", "Adds new timing to the project. Note: current project must be specified first")
            {
                offset,
                bpm,
                subdivideBeats,
                beatSubdivision,
                speed,
                colorPatern
            };

            command.AddAlias("ti");

            command.SetHandler(AddNewTiming, offset, bpm, subdivideBeats, beatSubdivision, speed, colorPatern);

            return command;
        }

        private void AddNewTiming(ulong offset, double bpm, bool subdivideBeats, int beatSubdivision, int speed, string colorPattern)
        {
            if (workFlowManager.CurrentTimingProject.Name == string.Empty)
            {
                Console.WriteLine("Current project must be specified");

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
