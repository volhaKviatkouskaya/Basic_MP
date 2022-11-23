namespace CustomAttribute
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class ConfigurationItemAttribute : Attribute
    {
        public ConfigurationItemAttribute(string settingName, ProviderTypes providerType)
        {
            SettingName = settingName;
            ProviderType = providerType;
        }

        public string SettingName { get; set; }

        public ProviderTypes ProviderType { get; set; }
    }
}
