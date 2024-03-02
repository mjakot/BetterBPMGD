using BetterBPMGDCLI.CLICommands;
using BetterBPMGDCLI.Models.Settings;
using System.CommandLine;

namespace BetterBPMGDCLI.Managers
{
    public class CLIManager(WorkFlowManager workFlowManager)
    {
        private bool isRunning = false;

        private readonly WorkFlowManager workFlowManager = workFlowManager;

        public async Task RunAsync(string[] args)
        {
            Option<bool> continuous = new(["--continuous", "-c", "-t"], description: "Enables the continuous mode", getDefaultValue: () => false);

            RootCommand rootCommand =
            [
                continuous,

                StopCommand(),
                new TestCommand().BuildCommand(),
                new ClearCommand().BuildCommand(),
                new StatsCommand(workFlowManager).BuildCommand(),
                new SearchLevelsByNameCommand(workFlowManager).BuildCommand(),
                new NewCommand(new NewProject(workFlowManager), new NewTiming(workFlowManager)).BuildCommand(),
                new SetCommand(new SetCurrentProject(workFlowManager)).BuildCommand(),
            ];

            rootCommand.SetHandler((continuousEnable) =>
            {
                if (continuousEnable)
                    isRunning = true;
            }, continuous);

            _ = await rootCommand.InvokeAsync(args);

            while (isRunning)
            {
                string input = Console.ReadLine() ?? string.Empty;

                _ = await rootCommand.InvokeAsync(input);
            }

            workFlowManager.Dispose();

            await Console.Out.WriteLineAsync("Press enter to exit");

            Console.ReadLine();
        }

        private Command StopCommand()
        {
            Option<bool> deleteStartupFile = new(["--delete-startup-file", "--delete-startupFile", "--deleteStartupFile", "--startup", "--ds", "-s"], description: "Deletes startup file. (Not recommended)", getDefaultValue: () => false);
            Option<bool> deleteLocalFiles = new(["--delete-local-files", "--delete-localFiles", "--deleteLocalFiles", "--local", "--dl", "-l"], description: "Deletes local files. (Not recommended)", getDefaultValue: () => false);

            Command command = new("stop", "Stops the continuous mode")
            {
                deleteStartupFile,
                deleteLocalFiles
            };

            command.AddAlias("exit");
            command.AddAlias("quit");
            command.AddAlias(":q");

            command.SetHandler((deleteStartupFile, deleteLocalFiles) =>
            {
                if(deleteStartupFile)
                {
                    try { File.Delete(PathSettings.StartupFilePath); }
                    catch (Exception)
                    {
                        Console.Error.WriteLine("Startup file is already deleted");

                        throw;
                    }
                }

                if (deleteLocalFiles)
                {
                    try { Directory.Delete(workFlowManager.ConfigManager.PathSettings.BetterBPMGDFolderPath, true); }
                    catch (Exception)
                    {
                        Console.Error.WriteLine("Local files are already deleted");

                        throw;
                    }
                }

                if (deleteStartupFile && deleteLocalFiles) Environment.Exit(0);

                Console.WriteLine("Stopping the continuous mode...");

                isRunning = false;
            }, deleteStartupFile, deleteLocalFiles);

            return command;
        }
    }
}
