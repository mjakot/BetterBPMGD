﻿namespace Common
{
    public class Level
    {
        protected readonly List<Timing> timings;

        protected ulong songDurationMS;

        public virtual IEnumerable<Timing> Timings => timings;

        public virtual ulong SongDurationMS { get => songDurationMS; set => songDurationMS = value; }

        public Level()
        {
            songDurationMS = 0;
            timings = new List<Timing>();
        }

        public Level(IEnumerable<Timing> timings, ulong songDurationMS = 0)
        {
            this.songDurationMS = songDurationMS;
            this.timings = new(timings);
        }

        public Level(Timing timing, ulong songDurationMS = 0)
        {
            this.songDurationMS = songDurationMS;
            this.timings = new() { timing };
        }
    }
}
