using System.Text;

namespace BetterBPMGDCLI.Extensions
{
    public static class StringBuilderExtension
    {
        public static StringBuilder AddKeyValuePair<TKey, TValue>(this StringBuilder stringBuilder, TKey key, TValue value, string separator, bool addNewLine)
        {
            stringBuilder.Append(key?.ToString());
            stringBuilder.Append(separator);
            stringBuilder.Append(value?.ToString());

            if (addNewLine) stringBuilder.AppendLine();

            return stringBuilder;
        }

        public static StringBuilder AddDictionary<TKey, TValue>(this StringBuilder stringBuilder, IReadOnlyDictionary<TKey, TValue> dictionary, string separator)
        {
            Parallel.ForEach(dictionary, pair => stringBuilder.AddKeyValuePair(pair.Key, pair.Value, separator, true));

            return stringBuilder;
        }
    }
}
