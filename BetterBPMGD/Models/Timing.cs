using Common;

namespace BetterBPMGD.Models
{
    public class Timing : Common.Timing
    {
        public UnitsOfTime TimeUnit { get; set; }

        public Timing() : base()
        {
            TimeSignature = new Fraction(4, 4);
            TimeUnit = UnitsOfTime.milisecond;
        }

        public Timing(int Id) : base(Id) { }

        public Timing(ulong offsetms, UnitsOfTime timeUnit, double bpm, bool includeInBetweenBeats, Fraction timeSignature, SpeedPortalTypes speed, string colorPattern)
                        : base(offsetms, bpm, includeInBetweenBeats, timeSignature, speed, colorPattern)
        {
            TimeUnit = timeUnit;
        }
    }
}
