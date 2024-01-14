using System.Text;

namespace BetterBPMGDCLI.Extensions
{
    public static class StringBuilderExtension
    {
        public static StringBuilder AppendWithSeparator<T>(this StringBuilder stringBuilder, T content, string separator) => stringBuilder.Append(content)
                                                                                                                                            .Append(separator);

        public static StringBuilder ReversAppendWithSeparator<T>(this StringBuilder stringBuilder, string separator, T content) => stringBuilder.Append(separator)
                                                                                                                                                    .Append(content);

        public static StringBuilder AddKeyValuePair<TKey, TValue>(this StringBuilder stringBuilder, TKey key, TValue value, string separator, bool addNewLine)
        {
            stringBuilder.AppendWithSeparator(key?.ToString() ?? string.Empty, separator);
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
