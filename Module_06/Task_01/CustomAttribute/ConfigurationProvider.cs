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


        public void SetValue(string key, string value)
        {
            _configurationProvider[key] = value;
        }

        public void SaveChanges(string key, string value)
        {
            Configuration configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            KeyValueConfigurationCollection settings = configFile.AppSettings.Settings;

            if (settings[key] == null)
            {
                settings.Add(key,value);
            }
            else
            {
                settings.Remove(key);
                settings.Add(key,value);
            }

            configFile.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);

        }
    }
}
