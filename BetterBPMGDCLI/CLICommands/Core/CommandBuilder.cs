using BetterBPMGDCLI.Managers;
using BetterBPMGDCLI.Utils;
using System.CommandLine;
using System.CommandLine.Binding;
using System.CommandLine.Parsing;

namespace BetterBPMGDCLI.CLICommands
{
    /// <include file='..\..\Docs\Classes\CommandBuilderDoc.xml' path='doc/type'/>
    public class CommandBuilder<T> : ICommand where T : class, ICommand
    {
        private readonly ResourceManager<T> resourceManager;

        private readonly Command command;

        public CommandBuilder()
        {
            resourceManager = new(Constants.CLICommandsResourceType);

            string[] aliases = resourceManager.GetStringArray(Constants.CommandNameAliasesResourceKey);

            command = new(aliases[0], resourceManager.GetString(Constants.CommandDescriptionResourceKey));

            for (int i = 1; i < aliases.Length; i++)
                command.AddAlias(aliases[i]);

            command.SetHandler(() => CLIManager.ConsoleError<T>(Constants.DefaultMessageResourceKey));
        }

        public Command BuildCommand() => command;

        /// <include file='..\..\Docs\Classes\CommandBuilderDoc.xml' path='doc/method[@name="AddOptionSimple"]'/>
        public CommandBuilder<T> AddOption<OptionType>(bool isRequired = true) where OptionType : notnull, IConvertible => AddOption<OptionType>(isRequired, null, null, []);

        /// <include file='..\..\Docs\Classes\CommandBuilderDoc.xml' path='doc/method[@name="AddOptionFull"]'/>
        public CommandBuilder<T> AddOption<OptionType>(bool isRequired = true,
                                                        ValidateSymbolResult<OptionResult>? validator = null,
                                                        Func<OptionType>? getDefaultValue = null,
                                                        params string[] fromAmong)
                                                            where OptionType : notnull, IConvertible
        {
            string typeName = typeof(OptionType).Name.ToUpper();

            int sameTypeOptionsCount = command.Options.Count(option => option.GetType()
                                                                                .GetGenericArguments()
                                                                                .FirstOrDefault()
                                                                                ?.Equals(typeof(OptionType))
                                                                                ?? false);

            if (sameTypeOptionsCount > 0)
                typeName += Constants.ResourceKeySeparator + sameTypeOptionsCount;

            string optionAliasesKey = Constants.BaseOptionAliasesResourceKey.Insert(Constants.BaseOptionInsertionIndex, typeName);
            string optionDescriptionKey = Constants.BaseOptionDescriptionResourceKey.Insert(Constants.BaseOptionInsertionIndex, typeName);

            Option<OptionType> option;

            if (getDefaultValue is null)
                option = new(resourceManager.GetStringArray(optionAliasesKey), resourceManager.GetString(optionDescriptionKey));

            else
                option = new(resourceManager.GetStringArray(optionAliasesKey), getDefaultValue, resourceManager.GetString(optionDescriptionKey));

            option.ArgumentHelpName = typeName;
            option.IsRequired = isRequired;

            if (validator is not null)
                option.AddValidator(validator);

            if (fromAmong.Length != 0)
                option.FromAmong(fromAmong);

            command.AddOption(option);

            return this;
        }

        /// <include file='..\..\Docs\Classes\CommandBuilderDoc.xml' path='doc/method[@name="SetHandler0"]'/>
        public CommandBuilder<T> SetHandler(Action handler)
        {
            command.SetHandler(handler);
            
            return this;
        }

        /// <include file='..\..\Docs\Classes\CommandBuilderDoc.xml' path='doc/method[@name="SetHandler1"]'/>
        public CommandBuilder<T> SetHandler<T1>(Action<T1> handler) where T1 : notnull, IConvertible
        {
            command.SetHandler(handler, (IValueDescriptor<T1>)command.Options[0]);

            return this;
        }

        /// <include file='..\..\Docs\Classes\CommandBuilderDoc.xml' path='doc/method[@name="SetHandler2"]'/>
        public CommandBuilder<T> SetHandler<T1, T2>(Action<T1, T2> handler) where T1 : notnull, IConvertible
                                                                                where T2 : notnull, IConvertible
        {
            command.SetHandler(handler,
                                (IValueDescriptor<T1>)command.Options[0],
                                (IValueDescriptor<T2>)command.Options[1]);

            return this;
        }

        /// <include file='..\..\Docs\Classes\CommandBuilderDoc.xml' path='doc/method[@name="SetHandler3"]'/>
        public CommandBuilder<T> SetHandler<T1, T2, T3>(Action<T1, T2, T3> handler) where T1 : notnull, IConvertible
                                                                                        where T2 : notnull, IConvertible
                                                                                        where T3 : notnull, IConvertible
        {
            command.SetHandler(handler,
                                (IValueDescriptor<T1>)command.Options[0],
                                (IValueDescriptor<T2>)command.Options[1],
                                (IValueDescriptor<T3>)command.Options[2]);

            return this;
        }

        /// <include file='..\..\Docs\Classes\CommandBuilderDoc.xml' path='doc/method[@name="SetHandler4"]'/>
        public CommandBuilder<T> SetHandler<T1, T2, T3, T4>(Action<T1, T2, T3, T4> handler) where T1 : notnull, IConvertible
                                                                                                where T2 : notnull, IConvertible
                                                                                                where T3 : notnull, IConvertible
                                                                                                where T4 : notnull, IConvertible
        {
            command.SetHandler(handler,
                                (IValueDescriptor<T1>)command.Options[0],
                                (IValueDescriptor<T2>)command.Options[1],
                                (IValueDescriptor<T3>)command.Options[2],
                                (IValueDescriptor<T4>)command.Options[3]);

            return this;
        }

        /// <include file='..\..\Docs\Classes\CommandBuilderDoc.xml' path='doc/method[@name="SetHandler5"]'/>
        public CommandBuilder<T> SetHandler<T1, T2, T3, T4, T5>(Action<T1, T2, T3, T4, T5> handler) where T1 : notnull, IConvertible
                                                                                                        where T2 : notnull, IConvertible
                                                                                                        where T3 : notnull, IConvertible
                                                                                                        where T4 : notnull, IConvertible
                                                                                                        where T5 : notnull, IConvertible
        {
            command.SetHandler(handler,
                                (IValueDescriptor<T1>)command.Options[0],
                                (IValueDescriptor<T2>)command.Options[1],
                                (IValueDescriptor<T3>)command.Options[2],
                                (IValueDescriptor<T4>)command.Options[3],
                                (IValueDescriptor<T5>)command.Options[4]);

            return this;
        }

        /// <include file='..\..\Docs\Classes\CommandBuilderDoc.xml' path='doc/method[@name="SetHandler6"]'/>
        public CommandBuilder<T> SetHandler<T1, T2, T3, T4, T5, T6>(Action<T1, T2, T3, T4, T5, T6> handler) where T1 : notnull, IConvertible
                                                                                                                where T2 : notnull, IConvertible
                                                                                                                where T3 : notnull, IConvertible
                                                                                                                where T4 : notnull, IConvertible
                                                                                                                where T5 : notnull, IConvertible
                                                                                                                where T6 : notnull, IConvertible
        {
            command.SetHandler(handler,
                                (IValueDescriptor<T1>)command.Options[0],
                                (IValueDescriptor<T2>)command.Options[1],
                                (IValueDescriptor<T3>)command.Options[2],
                                (IValueDescriptor<T4>)command.Options[3],
                                (IValueDescriptor<T5>)command.Options[4],
                                (IValueDescriptor<T6>)command.Options[5]);

            return this;
        }

        /// <include file='..\..\Docs\Classes\CommandBuilderDoc.xml' path='doc/method[@name="SetHandler7"]'/>
        public CommandBuilder<T> SetHandler<T1, T2, T3, T4, T5, T6, T7>(Action<T1, T2, T3, T4, T5, T6, T7> handler) where T1 : notnull, IConvertible
                                                                                                                        where T2 : notnull, IConvertible
                                                                                                                        where T3 : notnull, IConvertible
                                                                                                                        where T4 : notnull, IConvertible
                                                                                                                        where T5 : notnull, IConvertible
                                                                                                                        where T6 : notnull, IConvertible
                                                                                                                        where T7 : notnull, IConvertible
        {
            command.SetHandler(handler,
                                (IValueDescriptor<T1>)command.Options[0],
                                (IValueDescriptor<T2>)command.Options[1],
                                (IValueDescriptor<T3>)command.Options[2],
                                (IValueDescriptor<T4>)command.Options[3],
                                (IValueDescriptor<T5>)command.Options[4],
                                (IValueDescriptor<T6>)command.Options[5],
                                (IValueDescriptor<T7>)command.Options[6]);

            return this;
        }

        /// <include file='..\..\Docs\Classes\CommandBuilderDoc.xml' path='doc/method[@name="SetHandler8"]'/>
        public CommandBuilder<T> SetHandler<T1, T2, T3, T4, T5, T6, T7, T8>(Action<T1, T2, T3, T4, T5, T6, T7, T8> handler) where T1 : notnull, IConvertible
                                                                                                                                where T2 : notnull, IConvertible
                                                                                                                                where T3 : notnull, IConvertible
                                                                                                                                where T4 : notnull, IConvertible
                                                                                                                                where T5 : notnull, IConvertible
                                                                                                                                where T6 : notnull, IConvertible
                                                                                                                                where T7 : notnull, IConvertible
                                                                                                                                where T8 : notnull, IConvertible
        {
            command.SetHandler(handler,
                                (IValueDescriptor<T1>)command.Options[0],
                                (IValueDescriptor<T2>)command.Options[1],
                                (IValueDescriptor<T3>)command.Options[2],
                                (IValueDescriptor<T4>)command.Options[3],
                                (IValueDescriptor<T5>)command.Options[4],
                                (IValueDescriptor<T6>)command.Options[5],
                                (IValueDescriptor<T7>)command.Options[6],
                                (IValueDescriptor<T8>)command.Options[7]);

            return this;
        }
    }
}
