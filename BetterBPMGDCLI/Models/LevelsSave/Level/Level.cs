using BetterBPMGDCLI.Models.LevelsSave.Level.LevelData;
using BetterBPMGDCLI.Models.LevelsSave.Level.LevelData.LevelDataCollection;
using Common;

namespace BetterBPMGDCLI.Models.LevelsSave.Level
{
    public class Level : Common.Level
    {
        public Level() : base() { }

        public Level(Timing timing, ulong songDurationMS) : base(timing, songDurationMS) { }

        public Level(IEnumerable<Timing> timings, ulong songDurationMS) : base(timings, songDurationMS) { }

        public void Add(Timing timing) => timings.Add(timing);

        public GuidelinesCollection CalculateGuidelines()
        {
            GuidelinesCollection guidelines = new();

            for (int i = 0; i < Timings.Count(); i++)
            {
                ulong nextOffset = (i + 1 < Timings.Count()) ? Timings.ElementAt(i + 1).OffsetMS : SongDurationMS;

                ulong beatDuration = BPMCalculations.CalculateBeatDuration(Timings.ElementAt(i).Bpm);

                ulong beatOffset = Timings.ElementAt(i).OffsetMS;

                while (beatOffset < nextOffset)
                {
                    char color = Timings.ElementAt(i).ColorPattern[0];

                    GuidelineColors guidelinescolor = GuidelineColors.GetGuidelineColor(color);

                    guidelines.Add(new Guideline(guidelinescolor, beatOffset));

                    beatOffset += beatDuration;
                }
            }

            return guidelines;
        }
    }
}
