// This file is used by Code Analysis to maintain SuppressMessage
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given
// a specific target and scoped to a namespace, type, member, etc.

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("Performance", "CA1834:Consider using 'StringBuilder.Append(char)' when applicable", Justification = "Not applicable here", Scope = "member", Target = "~M:BetterBPMGDCLI.Extensions.Serializer.Serialize``1(``0,System.Boolean)~System.String")]
[assembly: SuppressMessage("Performance", "CA1834:Consider using 'StringBuilder.Append(char)' when applicable", Justification = "Not applicable here", Scope = "member", Target = "~M:BetterBPMGDCLI.Models.LevelObjects.LevelObjectBase.Encode(System.Collections.Generic.Dictionary{System.String,System.String})~System.String")]

[assembly: SuppressMessage("Style", "IDE0059:Unnecessary assignment of a value", Justification = "Most probably necessary", Scope = "member", Target = "~M:BetterBPMGDCLI.Managers.WorkFlowManager.InjectToExisting(System.String)")]
[assembly: SuppressMessage("Style", "IDE0290:Use primary constructor", Justification = "Does not fit here", Scope = "member", Target = "~M:BetterBPMGDCLI.Managers.ConfigManager.#ctor(BetterBPMGDCLI.Models.Settings.IPathSettings)")]
[assembly: SuppressMessage("Style", "IDE0001:Simplify name", Justification = "Does not fit here", Scope = "member", Target = "~M:BetterBPMGDCLI.CLICommands.AddTiming.BuildCommand()")]
[assembly: SuppressMessage("Style", "IDE0001:Simplify name", Justification = "Does not fit here", Scope = "member", Target = "~M:BetterBPMGDCLI.CLICommands.SearchLevelsByNameCommand.BuildCommand()")]

[assembly: SuppressMessage("Naming", "VSSpell001:Spell Check", Justification = "Correct spelling", Scope = "namespace", Target = "~N:BetterBPMGDCLI.Utils")]
[assembly: SuppressMessage("Naming", "VSSpell001:Spell Check", Justification = "Correct spelling", Scope = "type", Target = "~T:BetterBPMGDCLI.Extensions.Serializer")]
[assembly: SuppressMessage("Naming", "VSSpell001:Spell Check", Justification = "Correct spelling", Scope = "type", Target = "~T:BetterBPMGDCLI.Models.Settings.PathSettings")]
[assembly: SuppressMessage("Naming", "VSSpell001:Spell Check", Justification = "Correct spelling", Scope = "member", Target = "~M:BetterBPMGDCLI.CLICommands.Core.CommandBuilder`1.AddOption``1(System.Boolean,System.CommandLine.Parsing.ValidateSymbolResult{System.CommandLine.Parsing.OptionResult},System.Func{``0},System.String[])~BetterBPMGDCLI.CLICommands.Core.CommandBuilder{`0}")]