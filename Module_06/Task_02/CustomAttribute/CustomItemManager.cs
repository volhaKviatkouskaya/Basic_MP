using System.Reflection;

namespace CustomAttribute
{
    public class CustomItemManager
    {
        private readonly Dictionary<string, IProvider> _providers;

        public CustomItemManager(string[] pathString)
        {
            _providers = new Dictionary<string, IProvider>();
            var providersDictionary = ProviderFinder.ReturnProviders(pathString);

            foreach (var provider in providersDictionary)
            {
                _providers.Add(provider.Key, provider.Value);
            }
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
            foreach (var keyValuePair in dataOfType)
            {
                var propertyInfo = item.GetType().GetProperty(keyValuePair.Key);
                var attributes = propertyInfo.GetCustomAttributes();

                foreach (var attribute in attributes)
                {
                    if (attribute is ConfigurationItemAttribute)
                    {
                        var key = keyValuePair.Value.SettingName;
                        var value = propertyInfo.GetValue(item).ToString();
                        var provider = keyValuePair.Value.ProviderType;

                        SetPropertyValue(key, value, provider);
                    }
                }
            }

            var providers = dataOfType.Values.Select(x => x.ProviderType).Distinct();
            foreach (var provider in providers)
            {
                SaveChanges(provider);
            }
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

        private void SaveChanges(string provider)
        {
            _providers[provider].SaveChanges();
        }

        private void SetPropertyValue(string key, string value, string provider)
        {
            _providers[provider].SetValue(key, value);
        }

        private string GetPropertyValue(string pairSettingName, string provider)
        {
            return _providers[provider].GetValue(pairSettingName);
        }
    }
}
