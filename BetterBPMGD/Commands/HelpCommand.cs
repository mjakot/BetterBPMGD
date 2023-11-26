using BetterBPMGD.ViewModels;
using System;

namespace BetterBPMGD.Commands
{
    public class HelpCommand : CommandBase
    {
        private readonly Action showHelp;

        public HelpCommand(Action showHelp)
        {
            this.showHelp = showHelp;
        }

        public override void Execute(object? parameter)
        {
            showHelp();
        }
    }
}
