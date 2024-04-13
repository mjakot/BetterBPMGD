using BetterBPMGD.Services;
using BetterBPMGD.ViewModels;

namespace BetterBPMGD
{
    public class ResetTimingCommand : CommandBase
    {
        private readonly BPMViewModel bpmViewModel;

        public ResetTimingCommand(BPMViewModel bpmViewModel)
        {
            this.bpmViewModel = bpmViewModel;
        }

        public override void Execute(object? parameter)
        {
            if (bpmViewModel.SelectedItem != null)
            {
                bpmViewModel.SelectedItem = new(new(bpmViewModel.SelectedItem!.ID));

                LevelProvider.Level.EditTiming(bpmViewModel.SelectedItem.Timing);
            }
        }
    }
}