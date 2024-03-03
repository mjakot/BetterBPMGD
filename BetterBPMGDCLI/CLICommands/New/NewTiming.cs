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
            Option<ulong> offset = new(["--offset", "-o"], description: "Specifies offset for the timing") { IsRequired = true };
            Option<double> bpm = new(["--bpm", "-b"], description: "Specifies bpm for the timing") { IsRequired = true };
            Option<bool> subdivideBeats = new(["--subdivide", "-d"], description: "Specifies whether to subdivide beats") { IsRequired = true };
            Option<int> beatSubdivision = new(["--subdivision", "-n"], description: "Specifies beat subdivision for the timing") { IsRequired = true };
            Option<int> speed = new(["--speed", "-s"], description: "Specifies speed for the timing") { IsRequired = true };
            Option<string> colorPatern = new(["--colors", "-c"], description: "Specifies color pattern for the timing") { IsRequired = true };

            Command command = new("timing", "Adds new timing to the project. Note: current project must be specified")
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
