using BetterBPMGD.Services;
using BetterBPMGD.ViewModels;

namespace BetterBPMGD
{
    public class NavigateCommand : CommandBase
    {
        private readonly NavigationService navigationService;

        public NavigateCommand(NavigationService navigationService) => this.navigationService = navigationService;

        public override void Execute(object? parameter) => navigationService.Navigate();
    }
}