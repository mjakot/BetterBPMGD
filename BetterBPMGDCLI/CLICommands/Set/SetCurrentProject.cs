using BetterBPMGDCLI.Managers;
using BetterBPMGDCLI.Utils;
using System.CommandLine;

namespace BetterBPMGDCLI.CLICommands
{
    /// <include file='..\..\Docs\Classes\SetCurrentProjectDoc.xml' path='doc/type'/>
    public class SetCurrentProject(WorkFlowManager workFlowManager) : ICommand
    {
        private readonly WorkFlowManager workFlowManager = workFlowManager;

        private readonly ResourceManager<SetCurrentProject> resourceManager = new(Constants.CLICommandsResourceType);

        public Command BuildCommand() => new CommandBuilder<SetCurrentProject>().AddOption<string>(true) // name
                                                                                .SetHandler<string>(SetProject)
                                                                                .BuildCommand(); //bye bye why not and cp :(, farewell bulky command declaration :(((

        private void SetProject(string name)
        {
            if (!Directory.Exists(Path.Combine(workFlowManager.ConfigManager.PathSettings.TimingProjectsFolderPath, name)))
            {
                Console.WriteLine(resourceManager.GetString(Constants.DoesNotExistsResourceKey));

                return;
            }

            workFlowManager.ReadExistingTimingProject(name);
        }
    }
}
