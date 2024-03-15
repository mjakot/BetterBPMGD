using BetterBPMGDCLI.CLICommands.Core;
using BetterBPMGDCLI.Extensions;
using BetterBPMGDCLI.Managers;
using System.CommandLine;
using System.Text;

namespace BetterBPMGDCLI.CLICommands
{
    public class StatsCommand(WorkFlowManager workFlowManager) : ICommand
    {
        private readonly WorkFlowManager workFlowManager = workFlowManager;

        public Command BuildCommand() => new CommandBuilder<StatsCommand>().SetHandler(DisplayDebugInfo)
                                                                             .BuildCommand();

        private void DisplayDebugInfo()
        {
            StringBuilder result = new();

            result.AppendLine("Current project:")
                    .AppendLine($"\tName - {workFlowManager.CurrentTimingProject.Name}")
                    .AppendLine()
                    .AppendLine("\tTimings - ");

            foreach (Common.Timing timing in workFlowManager.CurrentTimingProject.Timings)
            {
                result.AppendLine($"\t\t{timing.Serialize()}");
            }

            result.AppendLine()
                    .AppendLine("\tSongs - song id = song offset ");

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

            result.AppendLine()
                    .AppendLine($"Current culture: {Thread.CurrentThread.CurrentCulture}");

            Console.WriteLine(result.ToString());
        }
    }
}
