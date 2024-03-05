using System.CommandLine;

namespace BetterBPMGDCLI.CLICommands
{
    /// <include file="..\..\Docs\Classes\HostCommandBaseDoc.xml" path="doc/type"/>
    public abstract class HostCommandBase
    {
        /// <include file="..\..\Docs\Classes\HostCommandBaseDoc.xml" path="doc/method[@name='BuildCommandExcludeOptions']"/>
        protected static Command BuildCommand(ICommand[] commands, string[] aliases, string description, string defaultMessage) => BuildCommand(commands, aliases, [], description, defaultMessage);

        /// <include file="..\..\Docs\Classes\HostCommandBaseDoc.xml" path="doc/method[@name='BuildCommandIncludeOptions']"/>
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
