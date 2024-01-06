using BetterBPMGDCLI.Models.LevelManagement.Level;
using BetterBPMGDCLI.Models.LevelManagement.Level.LevelDataCollection;
using Common;
using System.Text;

namespace BetterBPMGDCLI.Models.LevelsSave.Level
{
    //TODO: Add and CalculateSpeedPortals()
    public class LocalLevelData : LevelDataBase
    {
        private const string GuidelinesKey = "kA14";

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

        private GuidelinesCollection CalculateGuidelines(IEnumerable<Timing> timings, ulong songDurationMS)
        {
            int timingsCount = timings.Count();
            
            GuidelinesCollection guidelines = new();

            for (int i = 0; i < timingsCount; i++)
            {
                ulong nextOffsetMs = (i + 1 < timingsCount) ? timings.ElementAt(i + 1).OffsetMS : songDurationMS;

                ulong beatDurationMs = BPMCalculations.CalculateBeatDuration(timings.ElementAt(i).Bpm);

                ulong beatOffsetMs = timings.ElementAt(i).OffsetMS;

                while (beatOffsetMs < nextOffsetMs)
                {
                    char color = timings.ElementAt(i).ColorPattern[0];

                    GuidelineColors guidelinescolor = GuidelineColors.GetGuidelineColor(color);

                    guidelines.Add(new Guideline(guidelinescolor, beatOffsetMs));

                    beatOffsetMs += beatDurationMs;
                }
            }

            return guidelines;
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

        public override string Encode()
        {
            throw new NotImplementedException();
        }

        public new static ILevelData? Parse(string data)
        {
            throw new NotImplementedException();
        }
    }
}
