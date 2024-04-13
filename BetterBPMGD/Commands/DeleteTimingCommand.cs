using BetterBPMGD.Services;
using BetterBPMGD.ViewModels;

namespace BetterBPMGD
{
    public class DeleteTimingCommand : CommandBase
    {
        private readonly BPMViewModel bpmViewModel;
        private int selectedTiming;

        public DeleteTimingCommand(BPMViewModel bpmViewModel)
        {
            this.bpmViewModel = bpmViewModel;
            bpmViewModel.PropertyChanged += BpmViewModel_PropertyChanged;
        }

        private void BpmViewModel_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName != "SelectedItem" | bpmViewModel.SelectedItem == null) return;

            selectedTiming = bpmViewModel.SelectedItem!.ID;
        }

        public override void Execute(object? parameter)
        {
            if (bpmViewModel.SelectedItem != null) LevelProvider.Level.RemoveTiming(selectedTiming);
        }
    }
}