using BetterBPMGD.Commands;
using System.Windows.Input;

namespace BetterBPMGD.ViewModels
{
    public class HelpViewModel : ViewModelBase
    {
        private readonly string helpText;

        public string HelpText => helpText;

        public ICommand CloseHelpPopupCommand { get; }

        public HelpViewModel(string helpText)
        {
            this.helpText = helpText;
            CloseHelpPopupCommand = new CloseViewCommand(ClosePopup);
        }

        private void ClosePopup()
        {

        }
    }
}
