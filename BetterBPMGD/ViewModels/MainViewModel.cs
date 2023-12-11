using BetterBPMGD.Stores;

namespace BetterBPMGD.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly NavigationStore navigationStore;

        public ViewModelBase CurrentViewModel => navigationStore.CurrentViewModel;

        public MainViewModel(NavigationStore navigationStore)
        {
            this.navigationStore = navigationStore;

            navigationStore.CurrentViewModelChanged += NavigationStore_CurrentViewModelChanged;
        }

        private void NavigationStore_CurrentViewModelChanged() => OnPropertyChanged(nameof(CurrentViewModel));
    }
}
