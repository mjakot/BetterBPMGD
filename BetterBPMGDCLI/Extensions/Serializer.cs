using BetterBPMGDCLI.Utils;
using System.ComponentModel;
using System.Reflection;
using System.Text;

namespace BetterBPMGDCLI.Extensions
{
    public static class Serializer
    {
        public static string Serialize<T>(this T type, bool oneLine = true)
        {
            IReadOnlyList<PropertyInfo> properties = typeof(T).GetProperties();

            StringBuilder stringBuilder = new();

            foreach (PropertyInfo property in properties)
            {    
                stringBuilder.AddKeyValuePair(property.Name, property.GetValue(type, null), Constants.DefaultInnerSeparator, !oneLine);

                if (oneLine) stringBuilder.Append(Constants.DefaultOuterSeparator);
            }

            return stringBuilder.ToString();
        }

        public static T Desirialize<T>(this string type, bool oneLine = true) where T : new()
        {
            T instance = new T();

            PropertyInfo[] properties = typeof(T).GetProperties();

            Dictionary<PropertyInfo, object> desirializedProperties = [];

            string separator = oneLine ? Constants.DefaultOuterSeparator : Environment.NewLine;

            IReadOnlyList<string> splittedProperties = type.Split(separator);

            foreach (string property in splittedProperties)
            {
                IReadOnlyList<string> keyValuePair = property.Split(Constants.DefaultInnerSeparator);

                int index = Array.FindIndex(properties, prop => prop.Name == keyValuePair[0]);

                if (index == -1) continue;

                PropertyInfo propertyInfo = properties[index];

                propertyInfo.SetValue(instance, TypeDescriptor.GetConverter(propertyInfo.PropertyType).ConvertFrom(keyValuePair[1]) ?? string.Empty);
            }

            return instance;
        }
    }
}
