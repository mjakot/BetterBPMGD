namespace Common
{
    public class Level
    {
        protected readonly List<Timing> timings;

        virtual public IEnumerable<Timing> Timings => timings;

        public Level() => timings = new();

        public Level(IEnumerable<Timing> timings) => this.timings = new(timings);

        public Level(Timing timing) => timings = new() { timing };
    }
}
