using System.Reflection;

namespace CustomAttribute
{
    public class CustomItemManager
    {
        private readonly IProvider _configurationProvider;
        private readonly IProvider _fileJsonProvider;

        public CustomItemManager()
        {
            _configurationProvider = new ConfigurationProvider();
            _fileJsonProvider = new FileProvider();
        }

        public void SetItemProperties(CustomItem item)
        {
            var customTypePropAttributes = ReturnItemProperties(typeof(CustomItem));

            AssignItemProperties(item, customTypePropAttributes);
        }

        private Dictionary<string, ConfigurationItemAttribute> ReturnItemProperties(Type type)
        {
            var propertyInfo = type.GetProperties();

            Dictionary<string, ConfigurationItemAttribute> pairs = new();

            foreach (var property in propertyInfo)
            {
                var customAttributes = property.GetCustomAttributes();

                foreach (var attribute in customAttributes)
                {
                    if (attribute is ConfigurationItemAttribute)
                    {
                        pairs.Add(property.Name, (ConfigurationItemAttribute)attribute);
                    }
                }
            }

            return pairs;
        }

        private void AssignItemProperties(object obj, Dictionary<string, ConfigurationItemAttribute> dataOfType)
        {
            foreach (var pair in dataOfType)
            {
                var pairSettingName = pair.Value.SettingName;
                var pairValue = GetPropertyValue(pairSettingName, pair.Value.ProviderType);
                var propertyType = obj.GetType().GetProperty(pair.Key).PropertyType;

                var adjustedValue = Convert(pairValue, propertyType);

                if (adjustedValue != null)
                {
                    obj.GetType().GetProperty(pair.Key).SetValue(obj, adjustedValue);
                }
            }
        }

        private object? Convert(string pairValue, Type propertyType)
        {
            switch (propertyType.Name)
            {
                case "String":
                    return pairValue;
                case "Int32":
                    return int.Parse(pairValue);
                case "Single":
                    return float.Parse(pairValue);
                case "TimeSpan":
                    return TimeSpan.Parse(pairValue);
                default:
                    return null;
            }
        }

        private string GetPropertyValue(string pairSettingName, string provider)
        {
            switch (provider)
            {
                case "ConfigurationProvider":
                    return _configurationProvider.GetValue(pairSettingName);
                case "FileProvider":
                    return _fileJsonProvider.GetValue(pairSettingName);
                default:
                    return null;

            }
        }
    }
}
