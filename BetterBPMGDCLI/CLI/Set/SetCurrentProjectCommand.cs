﻿using BetterBPMGDCLI.Managers;
using System.CommandLine;

namespace BetterBPMGDCLI.CLI
{
    public class SetCurrentProjectCommand(WorkFlowManager workFlowManager) : ICommand
    {
        private readonly WorkFlowManager workFlowManager = workFlowManager;

        public Command BuildCommand()
        {
            Option<string> name = new(["--name", "-n"], description: "Specifies the name of the project");

            Command command = new("proj", "Specifies the current timing project")
            {
                name
            };

            command.AddAlias("currentproject");
            command.AddAlias("currproj"); // aint no way im adding "cp" as alias

            command.SetHandler(SetCurrentProject, name);

            return command;
        }

        private void SetCurrentProject(string name)
        {
            if (!Directory.Exists(Path.Combine(workFlowManager.configManager.PathSettings.TimingProjectsFolderPath, name)))
            {
                Console.WriteLine("Project with this name does not exist");

                return;
            }

            workFlowManager.ReadExistingTimingProject(name);
        }
    }
}