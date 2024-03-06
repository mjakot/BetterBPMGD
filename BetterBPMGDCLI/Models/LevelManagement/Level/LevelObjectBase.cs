using BetterBPMGDCLI.Extensions;
using BetterBPMGDCLI.Models.Level;
using BetterBPMGDCLI.Utils;
using System.Text;

namespace BetterBPMGDCLI.Models.LevelObjects
{
    public abstract class LevelObjectBase(int objectId, double posX, double posY) : ILevelData
    {
        public virtual int ObjectId { get; } = objectId;
        public virtual double PositionX { get; set; } = posX;
        public virtual double PositionY { get; set; } = posY;

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
        public static LevelObjectBase? Parse(string data) => throw new NotImplementedException();
    }
}
