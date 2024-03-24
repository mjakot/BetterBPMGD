using System.Text;

namespace BetterBPMGDCLI.Extensions
{
    public static class StringBuilderExtension
    {
        public static StringBuilder AppendWithSeparator<T>(this StringBuilder stringBuilder, T content, string separator) => stringBuilder.Append(content)
                                                                                                                                            .Append(separator);

        public static StringBuilder ReversAppendWithSeparator<T>(this StringBuilder stringBuilder, string separator, T content) => stringBuilder.Append(separator)
                                                                                                                                                    .Append(content);

        public static StringBuilder AppendKeyValuePair<TKey, TValue>(this StringBuilder stringBuilder, TKey key, TValue value, string separator, bool addNewLine)
        {
            stringBuilder.AppendWithSeparator(key?.ToString() ?? string.Empty, separator);
            stringBuilder.Append(value?.ToString());

            if (addNewLine)
                stringBuilder.AppendLine();

            return stringBuilder;
        }

        public static StringBuilder AppendDictionary<TKey, TValue>(this StringBuilder stringBuilder, IReadOnlyDictionary<TKey, TValue> dictionary, string separator)
        {
            foreach (KeyValuePair<TKey, TValue> pair in dictionary)
                stringBuilder.AppendKeyValuePair(pair.Key, pair.Value, separator, true);

            return stringBuilder;
        }

        public static StringBuilder AppendIndented<T>(this StringBuilder stringBuilder, T content, int indentIndex = 1)
        {
            string[] lines = content?.ToString()?.Split(Environment.NewLine) ?? [];

            if (lines.Length == 0)
                return stringBuilder;

            for (int i = 0; i < lines.Length; i++)
            {
                if (string.IsNullOrEmpty(lines[i]))
                    continue;

                lines[i] = lines[i].PadLeft(lines[i].Length + 4 * indentIndex);
            }

            return stringBuilder.Append(string.Join(Environment.NewLine, lines))
                                    .AppendLine();
        }
    }
}
