using BetterBPMGDCLI.Utils;
using System.Text;

namespace BetterBPMGDCLI.Models.LevelsSave
{
    public abstract class BaseLocalLevelCipher : Base64Conversion
    {
        protected string localLevelsString;
        protected byte[] localLevelsByteArray;

        public virtual string LocalLevelsString => localLevelsString;
        public virtual byte[] LocalLevelsByteArray => localLevelsByteArray;

        public BaseLocalLevelCipher(string localLevelsString)
        {
            this.localLevelsString = localLevelsString;
            localLevelsByteArray = Encoding.UTF8.GetBytes(localLevelsString);
        }

        public BaseLocalLevelCipher(byte[] localLevelsByteArray)
        {
            this.localLevelsByteArray = localLevelsByteArray;
            localLevelsString = Encoding.UTF8.GetString(localLevelsByteArray);
        }
    }
}
