using Common;

namespace BetterBPMGD.Models
{
    public class Timing : Common.Timing
    {
        public UnitsOfTime TimeUnit { get; set; }

        public Timing() : base() => DefaultInitializer();

        public Timing(int Id) : base(Id) => DefaultInitializer();

        public Timing(ulong offsetms, UnitsOfTime timeUnit, double bpm, bool includeInBetweenBeats, Fraction timeSignature, SpeedPortalTypes speed, string colorPattern)
                : base(offsetms, bpm, includeInBetweenBeats, timeSignature, speed, colorPattern)
                => TimeUnit = timeUnit;

        private void DefaultInitializer()
        {
            TimeSignature = new Fraction(4, 4);
            TimeUnit = UnitsOfTime.milisecond;
        }
    }
}
