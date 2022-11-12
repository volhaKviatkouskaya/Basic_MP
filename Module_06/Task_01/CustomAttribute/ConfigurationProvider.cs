using System.Configuration;

namespace CustomAttribute
{
    public class ConfigurationProvider : IProvider
    {
        private readonly Dictionary<string, string> _configurationProvider;

        public ConfigurationProvider()
        {
            _configurationProvider = GetAppSettings();
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

        public string GetValue(string key)
        {
            return _configurationProvider[key];
        }

        public void SaveChanges(CustomItem item) => throw new NotImplementedException();
        public void SetValue(string key, string value, string provider) => throw new NotImplementedException();
    }
}
