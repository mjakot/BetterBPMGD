using BetterBPMGDCLI.Extensions;
using BetterBPMGDCLI.Models.Level;
using BetterBPMGDCLI.Utils;
using System.Text;

namespace BetterBPMGDCLI.Models.LevelObjects
{
    public abstract class LevelObjectBase : ILevelData
    {
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
            StringBuilder result = new StringBuilder().AppendWithSeparator(Constants.ObjectIdKey, Constants.DataSeparator)
                                                        .AppendWithSeparator(ObjectId, Constants.DataSeparator)
                                                        .AppendWithSeparator(Constants.PositionXKey, Constants.DataSeparator)
                                                        .AppendWithSeparator(PositionX, Constants.DataSeparator)
                                                        .AppendWithSeparator(Constants.PositionYKey, Constants.DataSeparator)
                                                        .Append(PositionY);

            foreach (KeyValuePair<string, string> property in objectProperties)
                result.ReversAppendWithSeparator(Constants.DataSeparator, property.Key)
                        .ReversAppendWithSeparator(Constants.DataSeparator, property.Value);

            return result.Append(Constants.ObjectEnd)
                            .ToString();
        }
        public static LevelObjectBase? Parse(string data) => null;
    }
}
