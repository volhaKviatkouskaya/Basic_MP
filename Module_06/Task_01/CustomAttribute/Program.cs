using System;
using System.Configuration;
using System.Reflection;
using CustomAttribute;

namespace CustomAttribute
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var appSett = GetAppSettings();

            var customManager = new CustomItemManager();
            var pairs = customManager.ReturnItemProperties(typeof(CustomItem));

            CustomItem item = new();
            AssignValueToProperty(item, "FirstItemProp", "New value");
            AssignValueToProperty(item, "SecondItemProp", 1111);

            PrintPropertyAttributes(pairs);
        }

        public static void AssignValueToProperty(object obj, string propName, dynamic value)
        {
            PropertyInfo propertyInfo = obj.GetType().GetProperty(propName);
            propertyInfo.SetValue(obj, value);
            Console.WriteLine(propertyInfo.GetValue(obj));
        }

        private static Dictionary<string, dynamic> GetAppSettings()
        {
            Dictionary<string, dynamic> appSettings = new();
            foreach (string key in ConfigurationManager.AppSettings)
            {
                if (key != null)
                {
                    var value = ConfigurationManager.AppSettings[key];
                    appSettings.Add(key,value);
                }
            }

            return appSettings;
        }

        private static object GetAppSettings(Type expectedType, string key)
        {
            string value = ConfigurationManager.AppSettings[key];
            if (expectedType == typeof(string))
            {
                return value;
            }

            return null;
        }

        private static void PrintPropertyAttributes(Dictionary<string, CustomAttributeData> pairs)
        {
            foreach (var customAttributeData in pairs)
            {
                Console.WriteLine($"Property: {customAttributeData.Key}, attribute: {customAttributeData.Value}");
            }
        }
    }
}
