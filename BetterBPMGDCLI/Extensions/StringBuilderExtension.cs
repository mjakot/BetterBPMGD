using System.Text;

namespace BetterBPMGDCLI.Extensions
{
    public static class StringBuilderExtension
    {
        public static StringBuilder AddKeyValuePair<TKey, TValue>(this StringBuilder stringBuilder, TKey key, TValue value, string separator)
            where TKey : notnull
            where TValue : notnull
        {
            stringBuilder.Append(key.ToString());
            stringBuilder.Append(separator);
            stringBuilder.Append(value.ToString());

            return stringBuilder;
        }

        public static StringBuilder AddDictionary<TKey, TValue>(this StringBuilder stringBuilder, IReadOnlyDictionary<TKey, TValue> dictionary, string separator)
            where TKey : notnull
            where TValue : notnull
        {
            Parallel.ForEach(dictionary, pair =>
            {
                stringBuilder.AddKeyValuePair(pair.Key, pair.Value, separator);
            });

            return stringBuilder.Append(Environment.NewLine);
        }
    }
}
