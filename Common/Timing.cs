namespace Common
{
    public class Timing
    {
        public static int Counter { get; private set; }

        public int Id { get; private set; }
        public ulong OffsetMS { get; set; }
        public double Bpm { get; set; }
        public bool SubdivideBeats { get; set; }
        [Obsolete("This property is obsolete and soon will be removed")]
        public Fraction TimeSignature { get; set; }
        public int BeatSubdivisuon { get; set; }
        public SpeedPortalTypes Speed { get; set; }
        public string ColorPattern { get; set; }

        public Timing() : this(0, 0, false, new(4, 4), 1, SpeedPortalTypes.NORMAL, "o") { }

        public Timing(int Id) : this()
        {
            Counter--;
            this.Id = Id;
        }

        public Timing(ulong offsetms, double bpm, bool includeInBetweenBeats, Fraction timeSignature, int beatSubdivision, SpeedPortalTypes speed, string colorPattern)
        {
            Id = Counter++;
            OffsetMS = offsetms;
            Bpm = bpm;
            SubdivideBeats = includeInBetweenBeats;
            TimeSignature = timeSignature;
            BeatSubdivisuon = beatSubdivision;
            Speed = speed;
            ColorPattern = colorPattern;
        }
    }
}
