using System.Configuration;
using System.Reflection;
using System.Text.Json;

namespace CustomAttribute
{
    public class CustomItemManager
    {
        private readonly Dictionary<string, string> _appSettings;
        private readonly Dictionary<string, string> _appJsonFile;

        private const string JsonFilePath = "app_file.json";

        public CustomItemManager()
        {
            _appSettings = GetAppSettings();
            _appJsonFile = GetAppFile();
        }

        private Dictionary<string, string> GetAppSettings()
        {
            Dictionary<string, string> appSettingsData = new();

            foreach (string key in ConfigurationManager.AppSettings)
            {
                if (key != null)
                {
                    var value = ConfigurationManager.AppSettings[key];

                    if (value != null)
                    {
                        appSettingsData.Add(key, value);
                    }
                }
            }

            return appSettingsData;
        }

        private Dictionary<string, string> GetAppFile()
        {
            var jsonFile = File.ReadAllText(JsonFilePath);
            Dictionary<string, string> jsonData = JsonSerializer.Deserialize<Dictionary<string, string>>(jsonFile);

            return jsonData;
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
            return provider == "ConfigurationProvider" ?
                                _appSettings[pairSettingName] :
                                _appJsonFile[pairSettingName];

        }
        
    }
}
