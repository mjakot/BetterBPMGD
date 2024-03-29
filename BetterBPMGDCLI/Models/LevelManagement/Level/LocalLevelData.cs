﻿using BetterBPMGDCLI.Models.LevelObjects;
using BetterBPMGDCLI.Utils;
using Common;
using System.Text;
using System.Text.RegularExpressions;

namespace BetterBPMGDCLI.Models.Level
{
    //TODO: Add CalculateSpeedPortals()
    public partial class LocalLevelData
    {
        public const string GuideLinesPattern = """kA14,(.*?),""";
        public const string SpeedPortalsPattern = """;1,200|201|202|203|1334,2,\d+,3,\d+(?:,13\d+)?""";

        public string LevelData { get; set; }

        public List<Guideline> Guidelines { get; set; }
        public List<SpeedPortal> SpeedPortals { get; set; }

        public LocalLevelData()
        {
            LevelData = string.Empty;
            Guidelines = [];
            SpeedPortals = [];
        }

        public LocalLevelData(string levelData, List<Guideline> guidelines, List<SpeedPortal> speedPortals)
        {
            LevelData = levelData;
            Guidelines = guidelines;
            SpeedPortals = speedPortals;
        }

        public string Encode(bool clearLevelObjects)
        {
            StringBuilder result = new(GuidelinesRegex().Replace(LevelData, match => $"kA14,{EncodeLevelDataCollection(Guidelines)},"));

            if (clearLevelObjects)
            {
                int startIndex = result.ToString().IndexOf(Constants.ObjectEnd);

                if (startIndex == -1)
                    goto end;

                result.Remove(++startIndex, result.Length - startIndex);
            }

        end:
            return result.Append(EncodeLevelDataCollection(SpeedPortals))
                            .ToString();
        }

        public static LocalLevelData? Parse(string data)
        {
            List<Guideline> guidelines = [];
            List<SpeedPortal> speedPortals = [];

            Match guidelineMatch = GuidelinesRegex().Match(data);
            MatchCollection speedPortalsMatches = SpeedPortalsRegex().Matches(data);

            {
                GroupCollection captured = guidelineMatch.Groups;

                //index == 0 is entire match
                guidelines.AddRange(Guideline.ParseGuidelines(captured[1].Value));
            }

            Parallel.ForEach(speedPortalsMatches, match => speedPortals.Add(SpeedPortal.Parse(match.Value)));

            return new(data, guidelines, speedPortals);
        }

        public void Calculate(IReadOnlyList<Timing> timings, ulong songDurationMS)
        {
            CalculateGuidelines(timings, songDurationMS);
            CalculateSpeedPortals();
        }

        private void CalculateGuidelines(IReadOnlyList<Timing> timings, ulong songDurationMS)
        {
            Guidelines.Clear();

            for (int i = 0; i < timings.Count; i++)
            {
                ulong nextOffsetMs = (i + 1 < timings.Count) ? timings[i + 1].OffsetMS : songDurationMS;

                ulong beatDurationMs = BPMCalculations.CalculateBeatDuration(timings[i].Bpm);

                ulong beatOffsetMs = timings[i].OffsetMS;

                while (beatOffsetMs < nextOffsetMs)
                {
                    char color = timings[i].ColorPattern[0];

                    GuidelineColors guidelinescolor = GuidelineColors.GetGuidelineColor(color);

                    Guidelines.Add(new Guideline(beatOffsetMs, guidelinescolor));

                    beatOffsetMs += beatDurationMs;
                }
            }
        }

        private void CalculateSpeedPortals() => SpeedPortals = [];

        private static string EncodeLevelDataCollection(IReadOnlyList<ILevelData> levelData)
        {
            StringBuilder stringBuilder = new();

            foreach (var data in levelData)
                stringBuilder.Append(data.Encode());

            return stringBuilder.ToString();
        }

        [GeneratedRegex(GuideLinesPattern)]
        private static partial Regex GuidelinesRegex();

        [GeneratedRegex(SpeedPortalsPattern)]
        private static partial Regex SpeedPortalsRegex();
    }
}
