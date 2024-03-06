using System.CommandLine;

namespace BetterBPMGDCLI.CLICommands
{
    public abstract class HostCommandBase
    {
        protected static Command BuildCommand(ICommand[] commands, string[] aliases, string description, string defaultMessage)
            => BuildCommand(commands, aliases, [], description, defaultMessage);

        protected static Command BuildCommand(ICommand[] commands, string[] aliases, Option[] options, string description, string defaultMessage)
        {
            Command command = new(aliases[0], description);

            foreach (ICommand cmd in commands)
                command.AddCommand(cmd.BuildCommand());

            foreach (Option option in options)
                command.AddOption(option);

            for (int i = 1; i < aliases.Length; i++)
                command.AddAlias(aliases[i]);

            command.SetHandler(() => Console.WriteLine(defaultMessage));

           return command;
        }
    }
}
