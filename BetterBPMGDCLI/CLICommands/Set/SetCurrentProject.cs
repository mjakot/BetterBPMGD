using BetterBPMGDCLI.Managers;
using BetterBPMGDCLI.Utils;
using System.CommandLine;

namespace BetterBPMGDCLI.CLICommands
{
    /// <include file='..\..\Docs\Classes\SetCurrentProjectDoc.xml' path='doc/type'/>
    public class SetCurrentProject(WorkFlowManager workFlowManager) : ICommand
    {
        private readonly WorkFlowManager workFlowManager = workFlowManager;

        public Command BuildCommand() => new CommandBuilder<SetCurrentProject>().AddOption<string>(true) // name
                                                                                .SetHandler<string>(SetProject)
                                                                                .BuildCommand(); //bye bye why not and cp :(, farewell bulky command declaration :(((

        private void SetProject(string name)
        {
            if (!Directory.Exists(Path.Combine(workFlowManager.ConfigManager.PathSettings.TimingProjectsFolderPath, name)))
            {
                CLIManager.ConsoleError<SetCurrentProject>(Constants.DoesNotExistsResourceKey);

                return;
            }

            workFlowManager.ReadExistingTimingProject(name);
        }
    }
}
