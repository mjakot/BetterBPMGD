﻿using BetterBPMGDCLI.Managers;
using BetterBPMGDCLI.Models.Settings;
using BetterBPMGDCLI.Utils;
using System.CommandLine;

namespace BetterBPMGDCLI.CLICommands
{
    /// <include file='..\Docs\Classes\StopCommandDoc.xml' path='doc/type'/>
    public class StopCommand(CLIManager cliManager, WorkFlowManager workFlowManager) : ICommand
    {
        private readonly CLIManager cLIManager = cliManager;
        private readonly WorkFlowManager workFlowManager = workFlowManager;

        public Command BuildCommand()
        {
            return new CommandBuilder<StopCommand>().AddOption(false, null, () => false)     // delete startup file
                                                        .AddOption(false, null, () => false) // delete local files
                                                        .AddOption(false, null, () => false) // delete backup files
                                                        .SetHandler<bool, bool, bool>(Stop)
                                                        .BuildCommand();
        }

        private void Stop(bool deleteStartupFile, bool deleteLocalFiles, bool deleteBackupFiles)
        {
            if (deleteStartupFile)
            {
                try { File.Delete(PathSettings.StartupFilePath); }
                catch (Exception)
                {
                    CLIManager.ConsoleError<StopCommand>(Constants.DoesNotExistsResourceKey);

                    throw;
                }
            }

            if (deleteLocalFiles)
            {
                try { Directory.Delete(workFlowManager.ConfigManager.PathSettings.BetterBPMGDFolderPath, true); }
                catch (Exception)
                {
                    CLIManager.ConsoleError<StopCommand>(Constants.DoesNotExistsResourceKey, 1);

                    throw;
                }
            }

            if (deleteBackupFiles)
            {
                try { Directory.Delete(workFlowManager.ConfigManager.PathSettings.BackupFolderPath, true); }
                catch (Exception)
                {
                    CLIManager.ConsoleError<StopCommand>(Constants.DoesNotExistsResourceKey, 2);

                    throw;
                }
            }


            if (deleteStartupFile && deleteLocalFiles)
                Environment.Exit(0);

            CLIManager.ConsoleMessage<StopCommand>(Constants.SuccessResourceKey);

            cLIManager.InvokeStop();
        }
    }
}
