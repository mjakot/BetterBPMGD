using System.ComponentModel;
using System.Reflection;
using System.Text;

namespace BetterBPMGDCLI.Extensions
{
    public static class Serializer
    {
        public const string DefaultInnerSeparator = "=";
        public const string DefaultOuterSeparator = ",";

        public static string Serialize<T>(this T type, bool oneLine = true)
        {
            IReadOnlyList<PropertyInfo> properties = typeof(T).GetProperties();

            StringBuilder stringBuilder = new();

            Parallel.ForEach(properties, property =>
            {
                stringBuilder.AddKeyValuePair(property.Name, property.GetValue(type, null), DefaultInnerSeparator, !oneLine);

                if (oneLine) stringBuilder.Append(DefaultOuterSeparator);
            });

            return stringBuilder.ToString();
        }

        public static T Desirialize<T>(this string type, bool oneLine = true) where T : new()
        {
            T instance = new T();

            PropertyInfo[] properties = typeof(T).GetProperties();

            Dictionary<PropertyInfo, object> desirializedProperties = [];

            string separator = oneLine ? DefaultOuterSeparator : Environment.NewLine;

            IReadOnlyList<string> splittedProperties = type.Split(separator);

            Parallel.ForEach(splittedProperties, property =>
            {
                IReadOnlyList<string> keyValuePair = property.Split(DefaultInnerSeparator);

                int index = Array.FindIndex(properties, prop => prop.Name == keyValuePair[0]);

                if (index != -1) return;

                PropertyInfo propertyInfo = properties[index];

                propertyInfo.SetValue(instance, TypeDescriptor.GetConverter(propertyInfo.PropertyType).ConvertFrom(keyValuePair[1]) ?? string.Empty);
            });

            return instance;
        }
    }
}
