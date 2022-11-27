using Microsoft.Extensions.Primitives;
using System.Text;

namespace CustomAttribute
{
    public class FileProviderItem
    {
        [ConfigurationItem(nameof(StringValue), ProviderType.FileProvider)]
        public string StringValue { get; set; }

        [ConfigurationItem(nameof(IntValue), ProviderType.FileProvider)]
        public int IntValue { get; set; }

        [ConfigurationItem(nameof(FloatValue), ProviderType.FileProvider)]
        public float FloatValue { get; set; }

        [ConfigurationItem(nameof(TimeSpanValue), ProviderType.FileProvider)]
        public TimeSpan TimeSpanValue { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new();

            sb.AppendLine("FileProviderItem:");
            sb.AppendLine($"StringValue: {StringValue}");
            sb.AppendLine($"IntValue: {IntValue}");
            sb.AppendLine($"FloatValue: {FloatValue}");
            sb.AppendLine($"TimeSpanValue: {TimeSpanValue}");

            return sb.ToString();
        }
    }
}
