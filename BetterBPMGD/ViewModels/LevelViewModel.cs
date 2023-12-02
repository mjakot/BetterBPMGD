using BetterBPMGD.Models;
using System.Collections.Generic;

namespace BetterBPMGD.ViewModels
{
    public class LevelViewModel : ViewModelBase
    {
        private readonly Level level;

        public IEnumerable<Timing> LevelTimings => (IEnumerable<Timing>)level.Timings;

        public LevelViewModel(Level level) => this.level = level;

        public bool AddTiming(Timing timing)
        {
            bool result = level.AddTiming(timing);
            OnPropertyChanged(nameof(LevelTimings));
            return result;
        }

        public bool RemoveTiming(int timingId)
        {
            bool result = level.RemoveTiming(timingId);
            OnPropertyChanged(nameof(LevelTimings));
            return result;
        }

        public bool EditTiming(Timing timing)
        {
            bool result = level.EditTiming(timing);
            OnPropertyChanged(nameof(LevelTimings));
            return result;
        }
    }
}
