using BetterBPMGDCLI.Managers;
using BetterBPMGDCLI.Utils;
using System.CommandLine;

namespace BetterBPMGDCLI.CLICommands
{
    /// <include file='..\..\Docs\Classes\AddProjectDoc.xml' path='doc/type'/>
    public class AddProject(WorkFlowManager workFlowManager) : ICommand
    {
        private readonly WorkFlowManager workFlowManager = workFlowManager;

        public Command BuildCommand() => new CommandBuilder<AddProject>().AddOption<string>()   // name
                                                                            .AddOption<int>()   // song id
                                                                            .AddOption<ulong>() // offset
                                                                            .SetHandler<string, int, ulong>(CreateNewProject)
                                                                            .BuildCommand();

        private void CreateNewProject(string name, int sondId, ulong offset)
        {
            if (string.IsNullOrEmpty(name))
            {
                CLIManager.ConsoleError<AddProject>(Constants.CanNotBeAnEmptyStringResourceKey);

                return;
            }

            workFlowManager.NewTimingProject(name, sondId, offset);

            CLIManager.ConsoleSuccess<AddProject>(Constants.SuccessResourceKey);
            CLIManager.ConsoleSuccess<SetCurrentProject>(Constants.SuccessResourceKey);
        }
    }
}
