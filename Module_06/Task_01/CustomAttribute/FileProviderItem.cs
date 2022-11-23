using System.Text;

namespace CustomAttribute
{
    public class CustomItemFileProvider
    {
        [ConfigurationItem("StringValue", ProviderTypes.FileProvider)]
        public string FifthItemProp { get; set; }

        [ConfigurationItem("IntValue", ProviderTypes.FileProvider)]
        public int SixthItemProp { get; set; }

        [ConfigurationItem("FloatValue", ProviderTypes.FileProvider)]
        public float SeventhItemProp { get; set; }

        [ConfigurationItem("TimeSpanValue", ProviderTypes.FileProvider)]
        public TimeSpan EighthItemProp { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new();

            sb.AppendLine("CustomItemFileProvider:");
            sb.AppendLine($"FifthItemProp: {FifthItemProp}");
            sb.AppendLine($"SixthItemProp: {SixthItemProp}");
            sb.AppendLine($"SeventhItemProp: {SeventhItemProp}");
            sb.AppendLine($"EighthItemProp: {EighthItemProp}");

            return sb.ToString();
        }
    }
}
