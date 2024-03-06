using BetterBPMGDCLI.Extensions;
using BetterBPMGDCLI.Managers;
using System.CommandLine;
using System.Text;

namespace BetterBPMGDCLI.CLICommands
{
    public class StatsCommand(WorkFlowManager workFlowManager) : ICommand
    {
        private readonly WorkFlowManager workFlowManager = workFlowManager;

        public Command BuildCommand()
        {
            Command command = new("stats", "Shows all important values. For debugging.");

            command.SetHandler(DisplayDebugInfo);

            return command;
        }

        private void DisplayDebugInfo()
        {
            StringBuilder result = new();

            result.AppendLine("Current project:");

            result.AppendLine($"\tName - {workFlowManager.CurrentTimingProject.Name}");
            result.AppendLine();
            result.AppendLine("\tTimings - ");

            foreach (Common.Timing timing in workFlowManager.CurrentTimingProject.Timings)
            {
                result.AppendLine($"\t\t{timing.Serialize()}");
            }

            result.AppendLine();
            result.AppendLine("\tSongs - song id = song offset ");

            foreach (KeyValuePair<int, ulong> song in workFlowManager.CurrentTimingProject.SongIds)
            {
                result.AppendLine($"\t\t{song.Key}={song.Value}");
            }

            result.AppendLine();


            result.AppendLine("All projects:");

            foreach (string project in Directory.GetDirectories(workFlowManager.ConfigManager.PathSettings.TimingProjectsFolderPath))
            {
                result.AppendLine($"\t{project}");
            }

            Console.WriteLine(result.ToString());
        }
    }
}
