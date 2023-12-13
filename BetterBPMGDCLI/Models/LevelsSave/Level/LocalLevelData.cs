using BetterBPMGDCLI.Models.LevelsSave.Level.LevelData.LevelDataCollection;
using Common;
using System.Text;

namespace BetterBPMGDCLI.Models.LevelsSave.Level
{
    //TODO: Add and CalculateSpeedPortals()
    public class LocalLevelData : Level
    {
        private GuidelinesCollection guidelines;
        private SpeedPortalsCollection speedPortals;

        public string LevelData { get; }

        public GuidelinesCollection GuideLines => guidelines;
        public SpeedPortalsCollection SpeedPortals => speedPortals;

        public LocalLevelData(string levelData) : base()
        {
            LevelData = levelData;
            guidelines = new();
            speedPortals = new();
        }

        public LocalLevelData(string levelData, IEnumerable<Timing> timings, ulong songDurationMS) : base(timings, songDurationMS)
        {
            LevelData = levelData;
            guidelines = new();
            speedPortals = new();
        }

        public LocalLevelData(string levelData, Timing timing, ulong songDurationMS) : base(timing, songDurationMS)
        {
            LevelData = levelData;
            guidelines = new();
            speedPortals = new();
        }

        //TODO: add handling for when speedportals are disabled
        public string Encode(bool deleteOldGuideLines)
        {
            guidelines = CalculateGuidelines();

            string[] splittedData = LevelData.Split(',');

            //TODO: add handling for situation when not found
            int guidelinesKeyIndex = FindGuideLinesKeyIndex(splittedData);

            if (deleteOldGuideLines) splittedData[guidelinesKeyIndex + 1] = string.Empty;

            splittedData[guidelinesKeyIndex + 1] += GuideLines.Encode();

            StringBuilder result = new(string.Join(',', splittedData));

            result.Append(SpeedPortals.Encode());

            return result.ToString();
        }

        private static int FindGuideLinesKeyIndex(string[] splittedData)
        {
            for (int i = 0; i < splittedData.Length; i++)
                if (splittedData[i] == "kA14")
                    return i;

            return -1;
        }
    }
}
