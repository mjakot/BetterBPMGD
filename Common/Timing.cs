namespace Common
{
    public class Timing
    {
        public static int Counter { get; private set; }

        public int Id { get; private set; }
        public ulong OffsetMS { get; set; }
        public double Bpm { get; set; }
        public bool SubdivideBeats { get; set; }
        public int BeatSubdivision { get; set; }
        public SpeedPortalTypes Speed { get; set; }
        public string ColorPattern { get; set; }

        public Timing() : this(0, 0, false, 0, SpeedPortalTypes.NORMAL, "o") { }

        public Timing(int Id) : this()
        {
            Counter--;
            this.Id = Id;
        }

        public Timing(ulong offsetMs, double bpm, bool subdivideBeats, int beatSubdivision, SpeedPortalTypes speed, string colorPattern)
        {
            Id = Counter++;
            OffsetMS = offsetMs;
            Bpm = bpm;
            SubdivideBeats = subdivideBeats;
            BeatSubdivision = beatSubdivision;
            Speed = speed;
            ColorPattern = colorPattern;
        }

        public Timing(ulong offsetMs, double bpm, bool subdivideBeats, int beatSubdivision, SpeedPortalTypes speed, string colorPattern, int Id)
        {
            this.Id = Id;
            OffsetMS = offsetMs;
            Bpm = bpm;
            SubdivideBeats = subdivideBeats;
            BeatSubdivision = beatSubdivision;
            Speed = speed;
            ColorPattern = colorPattern;
        }
    }
}
