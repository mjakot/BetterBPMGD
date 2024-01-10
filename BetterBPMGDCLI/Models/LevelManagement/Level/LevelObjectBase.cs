using BetterBPMGDCLI.Models.Level;
using System.Text;

namespace BetterBPMGDCLI.Models.LevelObjects
{
    public abstract class LevelObjectBase : ILevelData
    {
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
            StringBuilder result = new($"{ObjectIdKey},{ObjectId},{PositionXKey},{PositionX},{PositionYKey},{PositionY}");

            foreach (KeyValuePair<string, string> property in objectProperties)
                result.Append($",{property.Key},{property.Value}");

            return result.Append(';')
                            .ToString();
        }
        public static LevelObjectBase? Parse(string data) => null;
    }
}
