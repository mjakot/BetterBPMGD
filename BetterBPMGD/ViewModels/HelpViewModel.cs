namespace BetterBPMGD.ViewModels
{
    public class HelpViewModel : ViewModelBase
    {
        private readonly string helpText;

        public string HelpText => helpText;

        public HelpViewModel(string helpText)
        {
            this.helpText = helpText;
        }
    }
}
