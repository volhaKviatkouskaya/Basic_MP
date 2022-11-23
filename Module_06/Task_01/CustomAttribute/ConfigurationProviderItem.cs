using System.Text;

namespace CustomAttribute
{
    public class ConfigurationProviderItem
    {
        [ConfigurationItem(nameof(StringValue), ProviderType.ConfigurationProvider)]
        [Obsolete]
        public string StringValue { get; set; }

        [ConfigurationItem(nameof(IntValue), ProviderType.ConfigurationProvider)]
        public int IntValue { get; set; }

        [ConfigurationItem(nameof(FloatValue), ProviderType.ConfigurationProvider)]
        public float FloatValue { get; set; }

        [ConfigurationItem(nameof(TimeSpanValue), ProviderType.ConfigurationProvider)]
        public TimeSpan TimeSpanValue { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new();

            sb.AppendLine("ConfigurationProvider:");
            sb.AppendLine($"StringValue: {StringValue}");
            sb.AppendLine($"IntValue: {IntValue}");
            sb.AppendLine($"FloatValue: {FloatValue}");
            sb.AppendLine($"TimeSpanValue: {TimeSpanValue}");

            return sb.ToString();
        }
    }
}
