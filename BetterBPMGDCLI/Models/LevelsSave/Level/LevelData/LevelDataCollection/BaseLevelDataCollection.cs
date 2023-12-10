using System.Collections;

namespace BetterBPMGDCLI.Models.LevelsSave.Level.LevelData.LevelDataCollection
{
    public abstract class BaseLevelDataCollection : ILevelDataCollection
    {
        protected List<ILevelData> collection;

        public IEnumerable<ILevelData> Collection => collection;

        public int Count => collection.Count;

        public bool IsSynchronized => throw new NotImplementedException();

        public object SyncRoot => throw new NotImplementedException();

        public BaseLevelDataCollection()
        {
            collection = new List<ILevelData>();
        }

        public void CopyTo(Array array, int index)
        {
            if (array == null) throw new ArgumentNullException(nameof(array));
            if (index < 0) throw new ArgumentOutOfRangeException(nameof(index));
            if (array.Rank != 1 || array is not ILevelData[]) throw new ArgumentException(nameof(array));

            try
            {
                Array.Copy(collection.ToArray(), 0, array, index, collection.Count);
            }
            catch (Exception)
            {
                throw new ArgumentException(nameof(array));
            }
        }

        public IEnumerator GetEnumerator() => collection.GetEnumerator();

        public abstract string Encode();
    }
}
