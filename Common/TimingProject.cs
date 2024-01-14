namespace Common
{
    public class TimingProject
    {
        protected readonly List<Timing> timings;

        protected ulong songDurationMS;

        public virtual IEnumerable<Timing> Timings => timings;

        public virtual ulong SongDurationMS { get => songDurationMS; set => songDurationMS = value; }

        public TimingProject()
        {
            songDurationMS = 0;
            timings = new List<Timing>();
        }

        public TimingProject(IEnumerable<Timing> timings, ulong songDurationMS = 0)
        {
            this.songDurationMS = songDurationMS;
            this.timings = new(timings);
        }

        public TimingProject(Timing timing, ulong songDurationMS = 0)
        {
            this.songDurationMS = songDurationMS;
            this.timings = new() { timing };
        }
    }
}
