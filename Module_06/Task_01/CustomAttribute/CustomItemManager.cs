using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Reflection.Metadata;

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

        public void ReadFromFile(CustomItem item)
        {
            var customTypePropAttributes = ReturnItemProperties(typeof(CustomItem));

            AssignItemProperties(item, customTypePropAttributes);
        }

        public void WriteToFile(CustomItem item)
        {
            var customTypePropAttributes = ReturnItemProperties(typeof(CustomItem));

            WriteItemProperties(item, customTypePropAttributes);

        }

        private void WriteItemProperties(CustomItem item, Dictionary<string, ConfigurationItemAttribute> dataOfType)
        {


        }

        /*
        public void WriteToFile(CustomItem item, string propertyName, string value)
        {
            if (value != null)
            {
                var propertyInfo = item.GetType().GetProperty(propertyName);
                var propertyType = propertyInfo.PropertyType;
                var propertyAttributes = propertyInfo.GetCustomAttributes(typeof(ConfigurationItemAttribute), true);
                var attributeValue = (ConfigurationItemAttribute)propertyAttributes.FirstOrDefault();

                var adjustedValue = Convert(value, propertyType);

                if (adjustedValue != null)
                {
                    propertyInfo.SetValue(item, adjustedValue);

                    SetPropertyValue(attributeValue.SettingName, value, attributeValue.ProviderType);
                    SavePropertyChanges(attributeValue.SettingName, value, attributeValue.ProviderType);
                }
            }
        }
*/
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

        public void SavePropertyChanges(string key, string value, string provider)
        {
            switch (provider)
            {
                case "ConfigurationProvider":
                    _configurationProvider.SaveChanges(key, value);
                    break;
                case "FileProvider":
                    _fileJsonProvider.SaveChanges(key, value);
                    break;
            }
        }

        public void SetPropertyValue(string key, string value, string provider)
        {
            switch (provider)
            {
                case "ConfigurationProvider":
                    _configurationProvider.SetValue(key, value);
                    break;
                case "FileProvider":
                    _fileJsonProvider.SetValue(key, value);
                    break;
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
