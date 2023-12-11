using Common;

namespace BetterBPMGD.Models
{
    public class Timing : Common.Timing
    {
        public UnitsOfTime TimeUnit { get; set; }

        public Timing() : base() => TimeUnit = UnitsOfTime.milisecond;

        public Timing(int Id) : base(Id) => TimeUnit = UnitsOfTime.milisecond;

        public Timing(ulong offsetms, UnitsOfTime timeUnit, double bpm, bool subdivideBeats, int beatSubdivision, SpeedPortalTypes speed, string colorPattern)
                : base(offsetms, bpm, subdivideBeats, beatSubdivision, speed, colorPattern)
                => TimeUnit = timeUnit;
    }
}
