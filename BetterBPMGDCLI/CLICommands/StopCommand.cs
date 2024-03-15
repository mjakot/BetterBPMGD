﻿using BetterBPMGDCLI.CLICommands.Core;
using BetterBPMGDCLI.Managers;
using BetterBPMGDCLI.Models.Settings;
using BetterBPMGDCLI.Utils;
using System.CommandLine;

namespace BetterBPMGDCLI.CLICommands
{
    public class StopCommand(CLIManager cliManager, WorkFlowManager workFlowManager) : ICommand
    {
        private readonly CLIManager cLIManager = cliManager;
        private readonly WorkFlowManager workFlowManager = workFlowManager;

        private readonly ResourceManager<StopCommand> resourceManager = new(Constants.ResourceTypes.CLICommands);

        public Command BuildCommand()
        {
            return new CommandBuilder<StopCommand>().AddOption(false, null, () => false)
                                                        .AddOption(false, null, () => false)
                                                        .AddOption(false, null, () => false)
                                                        .SetHandler<bool, bool, bool>(Stop)
                                                        .BuildCommand();
        }

        private void Stop(bool deleteStartupFile, bool deleteLocalFiles, bool deleteBackupFiles)
        {
#if DEBUG
            deleteBackupFiles = true;
            deleteLocalFiles = true;
            deleteStartupFile = true;
#endif

            if (deleteStartupFile)
            {
                try { File.Delete(PathSettings.StartupFilePath); }
                catch (Exception)
                {
                    Console.Error.WriteLine(resourceManager.GetString(Constants.CLICommandsResourcesKeys.DoesNotExists));

                    throw;
                }
            }

            if (deleteLocalFiles)
            {
                try { Directory.Delete(workFlowManager.ConfigManager.PathSettings.BetterBPMGDFolderPath, true); }
                catch (Exception)
                {
                    Console.Error.WriteLine(resourceManager.GetString(Constants.CLICommandsResourcesKeys.DoesNotExists + 1));

                    throw;
                }
            }

            if (deleteBackupFiles)
            {
                try { Directory.Delete(workFlowManager.ConfigManager.PathSettings.BackupFolderPath, true); }
                catch (Exception)
                {
                    Console.Error.WriteLine(resourceManager.GetString(Constants.CLICommandsResourcesKeys.DoesNotExists + 2));

                    throw;
                }
            }


            if (deleteStartupFile && deleteLocalFiles)
                Environment.Exit(0);

            Console.WriteLine(resourceManager.GetString(Constants.CLICommandsResourcesKeys.Success));

            cLIManager.InvokeStop();
        }
    }
}