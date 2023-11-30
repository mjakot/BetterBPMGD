﻿namespace BetterBPMGD.Models
{
    public class Timing
    {
        public static int Counter { get; private set; }

        public int Id { get; private set; }
        public ulong OffsetMS { get; set; }
        public UnitsOfTime TimeUnit { get; set; }
        public double Bpm { get; set; }
        public bool IncludeInBetweenBeats { get; set; }
        public Fraction TimeSignature { get; set; }
        public SpeedPortalTypes Speed { get; set; }
        public string ColorPattern { get; set; }

        public Timing() : this(0, UnitsOfTime.milisecond, 0, false, new(4, 4), SpeedPortalTypes.NORMAL, "o") { }

        public Timing(int Id) : this()
        {
            Counter--;
            this.Id = Id;
        }

        public Timing(ulong offsetms, UnitsOfTime timeUnit, double bpm, bool includeInBetweenBeats, Fraction timeSignature, SpeedPortalTypes speed, string colorPattern)
        {
            Id = Counter++;
            OffsetMS = offsetms;
            TimeUnit = timeUnit;
            Bpm = bpm;
            IncludeInBetweenBeats = includeInBetweenBeats;
            TimeSignature = timeSignature;
            Speed = speed;
            ColorPattern = colorPattern;
        }
    }
}
