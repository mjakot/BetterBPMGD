using BetterBPMGDCLI.Extensions;
using BetterBPMGDCLI.Managers;
using System.CommandLine;
using System.Text;

namespace BetterBPMGDCLI.CLICommands
{
    ///<include file='..\Docs\Classes\StatsCommandDoc.xml' path='doc/type'/>
    public class StatsCommand(WorkFlowManager workFlowManager) : ICommand
    {
        private readonly WorkFlowManager workFlowManager = workFlowManager;

        public Command BuildCommand() => new CommandBuilder<StatsCommand>().SetHandler(DisplayDebugInfo)
                                                                             .BuildCommand();

        private void DisplayDebugInfo()
        {
            StringBuilder result = new();

            result.AppendLine("Current project:")
                    .AppendIndented($"Name: {workFlowManager.CurrentTimingProject.Name}")
                    .AppendLine()
                    .AppendIndented("Timings:");

            foreach (Common.Timing timing in workFlowManager.CurrentTimingProject.Timings)
            {
                result.AppendIndented(timing.Serialize(), 2);
            }

            result.AppendLine()
                    .AppendIndented("Songs - song id = song offset:");

            foreach (KeyValuePair<int, ulong> song in workFlowManager.CurrentTimingProject.SongIds)
            {
                result.AppendIndented($"{song.Key}={song.Value}", 2);
            }

            result.AppendLine()
                    .AppendLine("All projects:");

            foreach (string project in Directory.GetDirectories(workFlowManager.ConfigManager.PathSettings.TimingProjectsFolderPath))
            {
                result.AppendIndented(project);
            }

            result.AppendLine()
                    .AppendLine($"Current culture: {Thread.CurrentThread.CurrentCulture}");

            result.AppendLine()
                    .AppendLine("Path settings - setting name = value:")
                    .AppendIndented(workFlowManager.ConfigManager.PathSettings.Serialize(false));

            CLIManager.ConsoleMessage(result.ToString(), ConsoleMessageTypes.Message);
        }
    }
}
