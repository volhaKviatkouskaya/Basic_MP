namespace CustomAttribute
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class ConfigurationItemAttribute : Attribute
    {
        public ConfigurationItemAttribute(string settingName, ProviderType providerType)
        {
            SettingName = settingName;
            ProviderType = providerType;
        }

        public string SettingName { get; set; }

        public ProviderType ProviderType { get; set; }
    }
}
