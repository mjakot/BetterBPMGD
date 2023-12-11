using BetterBPMGD.ViewModels;

namespace BetterBPMGD
{
    public class DeleteTimingCommand : CommandBase
    {
        private readonly LevelViewModel levelViewModel;
        private readonly BPMViewModel bpmViewModel;
        private int selectedTiming;

        public DeleteTimingCommand(LevelViewModel levelViewModel, BPMViewModel bpmViewModel)
        {
            this.levelViewModel = levelViewModel;
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
            if (bpmViewModel.SelectedItem != null) levelViewModel.RemoveTiming(selectedTiming);
        }
    }
}