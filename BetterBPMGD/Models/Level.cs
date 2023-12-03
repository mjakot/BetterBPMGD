using System.Collections.Generic;
using System.Linq;

namespace BetterBPMGD.Models
{
    public class Level : Common.Level
    {
        private readonly List<Timing> timings;

        public Level() : base() => timings = new();

        public Level(IEnumerable<Timing> timings) : base(timings) => this.timings = new(timings);

        public Level(Timing timing) : base(timing) => timings = new() { timing };

        public override IEnumerable<Common.Timing> Timings => timings;

        public bool AddTiming(Timing timing)
        {
            if (timing == null)
            {
                return false;
            }

            timings.Add(timing);
            
            return true;
        }

        public bool RemoveTiming(int timingId)
        {
            if (timings == null || timingId > Timing.Counter)
            {
                return false;
            }

            Timing? removeItem = (Timing)timings.SingleOrDefault(i => i.Id == timingId);

            return removeItem != null ? timings.Remove(removeItem) : false;
        }

        public bool EditTiming(Timing timing)
        {
            bool result = RemoveTiming(timing.Id);
            return result & AddTiming(timing);
        }
    }
}
