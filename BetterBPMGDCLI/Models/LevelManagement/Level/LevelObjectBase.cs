using BetterBPMGDCLI.Extensions;
using BetterBPMGDCLI.Models.Level;
using System.Text;

namespace BetterBPMGDCLI.Models.LevelObjects
{
    public abstract class LevelObjectBase : ILevelData
    {
        public const string DataSeparator = ",";
        public const string ObjectEnd = ";";

        public const string ObjectIdKey = "1";
        public const string PositionXKey = "2";
        public const string PositionYKey = "3";

        public virtual int ObjectId { get; }
        public virtual double PositionX { get; set; }
        public virtual double PositionY { get; set; }

        protected LevelObjectBase(int objectId, double posX, double posY)
        {
            ObjectId = objectId;
            PositionX = posX;
            PositionY = posY;
        }

        public abstract string Encode();
        public virtual string Encode(Dictionary<string, string> objectProperties)
        {
            StringBuilder result = new StringBuilder().AppendWithSeparator(ObjectIdKey, DataSeparator)
                                                        .AppendWithSeparator(ObjectId, DataSeparator)
                                                        .AppendWithSeparator(PositionXKey, DataSeparator)
                                                        .AppendWithSeparator(PositionX, DataSeparator)
                                                        .AppendWithSeparator(PositionYKey, DataSeparator)
                                                        .Append(PositionY);

            foreach (KeyValuePair<string, string> property in objectProperties)
                result.ReversAppendWithSeparator(DataSeparator, property.Key)
                        .ReversAppendWithSeparator(DataSeparator, property.Value);

            return result.Append(ObjectEnd)
                            .ToString();
        }
        public static LevelObjectBase? Parse(string data) => null;
    }
}
