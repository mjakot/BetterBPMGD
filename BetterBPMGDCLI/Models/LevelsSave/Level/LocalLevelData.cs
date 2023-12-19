using BetterBPMGDCLI.Models.LevelsSave.Level.LevelData.LevelDataCollection;
using Common;
using System.Text;

namespace BetterBPMGDCLI.Models.LevelsSave.Level
{
    //TODO: Add and CalculateSpeedPortals()
    public class LocalLevelData : Level
    {
        private const string GuidelinesKey = "kA14";

        private GuidelinesCollection guidelines;
        private SpeedPortalsCollection speedPortals;

        public string LevelKey { get; }
        public string LevelData { get; }

        public GuidelinesCollection GuideLines => guidelines;
        public SpeedPortalsCollection SpeedPortals => speedPortals;

        public LocalLevelData(string levelKey, string levelData) : base()
        {
            LevelKey = levelKey;
            LevelData = levelData;
            guidelines = new();
            speedPortals = new();
        }

        public LocalLevelData(string levelKey, string levelData, IEnumerable<Timing> timings, ulong songDurationMS) : base(timings, songDurationMS)
        {
            LevelKey = levelKey;
            LevelData = levelData;
            guidelines = new();
            speedPortals = new();
        }

        public LocalLevelData(string levelKey, string levelData, Timing timing, ulong songDurationMS) : base(timing, songDurationMS)
        {
            LevelKey = levelKey;
            LevelData = levelData;
            guidelines = new();
            speedPortals = new();
        }

        //TODO: add handling for when speedportals are disabled
        public string Encode(bool deleteOldGuideLines)
        {
            guidelines = CalculateGuidelines();

            string[] splittedData = LevelData.Split(',');

            int guidelinesKeyIndex = FindGuideLinesKeyIndex(splittedData);

            if (guidelinesKeyIndex == -1)
            {
                guidelinesKeyIndex = 2; //End of colors data

                splittedData = InsertGuidelinesKey(splittedData, guidelinesKeyIndex);
            }

            if (deleteOldGuideLines) splittedData[guidelinesKeyIndex + 1] = string.Empty;

            if (splittedData[guidelinesKeyIndex + 1] == "0") splittedData[guidelinesKeyIndex + 1] = string.Empty;

            splittedData[guidelinesKeyIndex + 1] += GuideLines.Encode();

            StringBuilder result = new(string.Join(',', splittedData));

            result.Append(SpeedPortals.Encode());

            return result.ToString();
        }

        private static int FindGuideLinesKeyIndex(string[] splittedData)
        {
            for (int i = 0; i < splittedData.Length; i++)
                if (splittedData[i] == GuidelinesKey)
                    return i;

            return -1;
        }

        private static string[] InsertGuidelinesKey(string[] levelData, int guidelinesKeyIndex)
        {
            List<string> splittedDataList = new(levelData);

            splittedDataList.Insert(guidelinesKeyIndex, GuidelinesKey);
            splittedDataList.Insert(guidelinesKeyIndex + 1, "0");

            return splittedDataList.ToArray();
        }
    }
}
