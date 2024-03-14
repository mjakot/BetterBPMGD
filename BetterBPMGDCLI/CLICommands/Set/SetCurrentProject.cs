﻿using BetterBPMGDCLI.Managers;
using System.CommandLine;

namespace BetterBPMGDCLI.CLICommands
{
    public class SetCurrentProject(WorkFlowManager workFlowManager) : ICommand
    {
        private readonly WorkFlowManager workFlowManager = workFlowManager;

        public Command BuildCommand()
        {
            Option<string> name = new(["--name", "-n"], description: "Specifies the name of the project")
            {
                ArgumentHelpName = "string"
            };

            Command command = new("proj", "Specifies the current timing project")
            {
                name
            };

            command.AddAlias("currentproject");
            command.AddAlias("currentProject");
            command.AddAlias("current-project");
            command.AddAlias("currproj");
            command.AddAlias("crpj");
            command.AddAlias("cpr"); // why not
            command.AddAlias("pj");

            command.SetHandler(SetProject, name);

            return command;
        }

        private void SetProject(string name)
        {
            if (!Directory.Exists(Path.Combine(workFlowManager.ConfigManager.PathSettings.TimingProjectsFolderPath, name)))
            {
                Console.WriteLine("Project with this name does not exist");

                return;
            }

            workFlowManager.ReadExistingTimingProject(name);
        }
    }
}
