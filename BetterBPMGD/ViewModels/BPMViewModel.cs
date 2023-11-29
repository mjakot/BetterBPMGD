using BetterBPMGD.Commands;
using BetterBPMGD.Models;
using BetterBPMGD.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace BetterBPMGD.ViewModels
{
    public class BPMViewModel : ViewModelBase
    {
        private readonly LevelViewModel level;

        private ObservableCollection<TimingViewModel> timings;
        private TimingViewModel? selectedItem;
        
        private bool showHelpPopup;
        
        private readonly HelpViewModel helpPopupDataContext;

        public IEnumerable<TimingViewModel> Timings => timings;

        public TimingViewModel? SelectedItem
        {
            get => selectedItem;
            set
            {
                if (selectedItem != value)
                {
                    selectedItem = value;
                    OnPropertyChanged(nameof(SelectedItem));
                }
            }
        }

        public bool ShowHelpPopup
        {
            get => showHelpPopup;
            set
            {
                showHelpPopup = value;
                OnPropertyChanged(nameof(ShowHelpPopup));
            }
        }

        public HelpViewModel HelpPopupDataContext => helpPopupDataContext;

        public ICommand PlayCommand { get; }
        public ICommand AddTimingCommand { get; }
        public ICommand DeleteTimingCommand { get; }
        public ICommand OpenSettingsCommand { get; }
        public ICommand RefineTimingCommand { get; }
        public ICommand ResetTimingCommand { get; }
        public ICommand ShowColorPatternHelpCommand { get; }
        public ICommand GenerateBarsCommand { get; }

        public BPMViewModel(LevelViewModel level, NavigationService settingsViewNavigationService)
        {
            this.level = level;

            PlayCommand = new PlayCommand();
            AddTimingCommand = new AddTimingCommand(this.level);
            DeleteTimingCommand = new DeleteTimingCommand(this.level, this);
            OpenSettingsCommand = new NavigateCommand(settingsViewNavigationService);
            RefineTimingCommand = new RefineTimingCommand();
            ResetTimingCommand = new ResetTimingCommand(this.level, this);
            ShowColorPatternHelpCommand = new ToggleHelpPopupCommand(ToggleHelpPopup);
            GenerateBarsCommand = new GenerateBarsCommand();

            timings = new ObservableCollection<TimingViewModel>(CreateTimingList(level.LevelTimings));

            level.PropertyChanged += Level_PropertyChanged;

            helpPopupDataContext = new("O - orange\nG - Green\nY - yellow", ToggleHelpPopup);
        }

        private void ToggleHelpPopup()
        {
            ShowHelpPopup = !ShowHelpPopup;
        }
        
        private IEnumerable<TimingViewModel> CreateTimingList(IEnumerable<Timing> timings)
        {
            foreach (Timing timing in timings)
            {
                yield return new(timing);
            }
        }

        private void Level_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            timings = new ObservableCollection<TimingViewModel>(CreateTimingList(level.LevelTimings));
            OnPropertyChanged(nameof(Timings));
        }
    }
}
