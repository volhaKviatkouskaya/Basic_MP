using System.Configuration;
using System.Reflection;

namespace CustomAttribute
{
    public class CustomItemManager
    {
        private readonly Dictionary<string, string> appSettings;

        public CustomItemManager()
        {
            appSettings = GetAppSettings();
        }

        public void SetItemProperties(CustomItem item)
        {
            var customTypePropAttributes = ReturnItemProperties(typeof(CustomItem));
            // PrintPropertyAttributes(customTypePropAttributes);

            AssignItemProperties(item, customTypePropAttributes);
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
                var pairValue = GetPropertyValue(pairSettingName);
                var adjustedValue = Convert(pairValue);

                if (pairValue != null)
                {
                    obj.GetType().GetProperty(pair.Key).SetValue(obj, adjustedValue);
                }
            }
        }

        private object Convert(string pairValue) => pairValue;

        private string GetPropertyValue(string pairSettingName) => appSettings[pairSettingName];

        private static void PrintPropertyAttributes(Dictionary<string, CustomAttributeData> pairs)
        {
            foreach (var customAttributeData in pairs)
            {
                Console.WriteLine($"Property: {customAttributeData.Key}, attribute: {customAttributeData.Value}");
            }
        }
    }
}
