using System.ComponentModel;
using System.Reflection;

namespace CustomAttribute
{
    public class CustomItemManager
    {
        private readonly Dictionary<ProviderType, IProvider> _providers;

        public CustomItemManager()
        {
            _providers = new Dictionary<ProviderType, IProvider>
                        {{ProviderType.ConfigurationProvider, new ConfigurationProvider() },
                        { ProviderType.FileProvider, new FileProvider() } };
        }

        public void ReadFromFile(object item)
        {
            var customTypePropAttributes = ReturnItemProperties(item.GetType());

            AssignItemProperties(item, customTypePropAttributes);
        }

        public void WriteToFile(object item)
        {
            var customTypePropAttributes = ReturnItemProperties(item.GetType());

            WriteItemProperties(item, customTypePropAttributes);
        }

        private void WriteItemProperties(object item, Dictionary<string, ConfigurationItemAttribute> dataOfType)
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
                        var provider = GetProviderType(keyValuePair.Value.ProviderType);

                        SetPropertyValue(key, value, provider);
                    }
                }
            }

            var providers = dataOfType.Values.Select(x => x.ProviderType).Distinct();
            foreach (var provider in providers)
            {
                SaveChanges(GetProviderType(provider));
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
                var providerType = GetProviderType(pair.Value.ProviderType);
                var pairValue = GetPropertyValue(pairSettingName, providerType);
                var propertyType = obj.GetType().GetProperty(pair.Key).PropertyType;

                var adjustedValue = ConvertValue(pairValue, propertyType);

                if (adjustedValue != null)
                {
                    obj.GetType().GetProperty(pair.Key).SetValue(obj, adjustedValue);
                }
            }
        }

        private object? ConvertValue(string pairValue, Type propertyType)
        {
            var converter = TypeDescriptor.GetConverter(propertyType);
            return converter.ConvertFromString(pairValue);
        }

        private void SaveChanges(ProviderType provider)
        {
            _providers[provider].SaveChanges();
        }

        private void SetPropertyValue(string key, string value, ProviderType provider)
        {
            _providers[provider].SetValue(key, value);
        }

        private string GetPropertyValue(string pairSettingName, ProviderType provider)
        {
            return _providers[provider].GetValue(pairSettingName);
        }

        private static ProviderType GetProviderType(ProviderType provider)
        {
            return provider == ProviderType.ConfigurationProvider
                ? ProviderType.ConfigurationProvider
                : ProviderType.FileProvider;
        }
    }
}
