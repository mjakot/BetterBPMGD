using System.Reflection;

namespace BetterBPMGDCLI.Models.Settings
{
    public abstract class SettingsBase : ISettings
    {
        protected Dictionary<string, object> defaultValues = [];

        public virtual object GetDefault(string propertyName)
        {
            PropertyInfo? property = GetType().GetProperty(propertyName);

            if (property is null)
                return string.Empty;

            if (defaultValues.TryGetValue(propertyName, out var defaultValue))
                return defaultValue;

            return string.Empty;
        }

        public virtual void ResetAll()
        {
            foreach (var property in GetType().GetProperties())
                if (defaultValues.TryGetValue(property.Name, out var defaultValue))
                    property.SetValue(this, defaultValue);
        }
        public abstract override string ToString();
        public static SettingsBase FromString(string settings) => throw new NotImplementedException();
    }
}
