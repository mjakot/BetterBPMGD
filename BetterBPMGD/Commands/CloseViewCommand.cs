using BetterBPMGD.ViewModels;
using System;

namespace BetterBPMGD.Commands
{
    public class CloseViewCommand : CommandBase
    {
        private readonly Action closuPopup;

        public CloseViewCommand(Action closuPopup)
        {
            this.closuPopup = closuPopup;
        }

        public override void Execute(object? parameter)
        {
            closuPopup();
        }
    }
}
