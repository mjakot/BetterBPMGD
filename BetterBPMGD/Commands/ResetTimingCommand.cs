using BetterBPMGD.ViewModels;

namespace BetterBPMGD
{
    public class ResetTimingCommand : CommandBase
    {
        private readonly LevelViewModel levelViewModel;
        private readonly BPMViewModel bpmViewModel;

        public ResetTimingCommand(LevelViewModel levelViewModel, BPMViewModel bpmViewModel)
        {
            this.levelViewModel = levelViewModel;
            this.bpmViewModel = bpmViewModel;
        }

        public override void Execute(object? parameter)
        {
            if (bpmViewModel.SelectedItem != null)
            {
                bpmViewModel.SelectedItem = new(new(bpmViewModel.SelectedItem!.ID));

                levelViewModel.EditTiming(bpmViewModel.SelectedItem.Timing);
            }
        }
    }
}