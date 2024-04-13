using BetterBPMGD.Models;
using BetterBPMGDCLI.Managers;
using System.Collections.Generic;

namespace BetterBPMGD.ViewModels
{
    public class LevelViewModel : ViewModelBase
    {
        private readonly Level level;
        private readonly WorkFlowManager workFlowManager;

        public IEnumerable<Timing> LevelTimings => (IEnumerable<Timing>)level.Timings;

        public LevelViewModel(Level level, WorkFlowManager workFlowManager)
        {
            this.level = level;
            this.workFlowManager = workFlowManager;
        }

        public bool AddTiming(Timing timing)
        {
            bool result = level.AddTiming(timing);
            workFlowManager.CurrentTimingProject.AddTiming(timing);
            OnPropertyChanged(nameof(LevelTimings));
            return result;
        }

        public bool RemoveTiming(int timingId)
        {
            bool result = level.RemoveTiming(timingId);
            workFlowManager.CurrentTimingProject.RemoveTiming(timingId);
            OnPropertyChanged(nameof(LevelTimings));
            return result;
        }

        public bool EditTiming(Timing timing)
        {
            bool result = level.EditTiming(timing);
            workFlowManager.CurrentTimingProject.RemoveTiming(timing.Id);
            workFlowManager.CurrentTimingProject.AddTiming(timing);
            //OnPropertyChanged(nameof(LevelTimings));
            return result;
        }
    }
}
