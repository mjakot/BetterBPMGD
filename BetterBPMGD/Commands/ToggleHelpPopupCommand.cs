using BetterBPMGD.ViewModels;
using System;

namespace BetterBPMGD.Commands
{
    public class ToggleHelpPopupCommand : CommandBase
    {
        private readonly Action toggleHelp;

        public ToggleHelpPopupCommand(Action toggleHelp)
        {
            this.toggleHelp = toggleHelp;
        }

        public override void Execute(object? parameter)
        {
            toggleHelp();
        }
    }
}
