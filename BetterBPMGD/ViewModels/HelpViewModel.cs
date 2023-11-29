using BetterBPMGD.Commands;
using System;
using System.Windows.Input;

namespace BetterBPMGD.ViewModels
{
    public class HelpViewModel : ViewModelBase
    {
        private readonly string helpText;

        public string HelpText => helpText;

        public ICommand CloseHelpPopupCommand { get; }

        public HelpViewModel(string helpText, Action ClosePopup)
        {
            this.helpText = helpText;
            CloseHelpPopupCommand = new ToggleHelpPopupCommand(ClosePopup);
        }
    }
}
