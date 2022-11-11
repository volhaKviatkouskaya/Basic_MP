using System.Text;

namespace CustomAttribute
{
    public class CustomItem
    {
        [ConfigurationItem("StringValue", "ConfigurationProvider")]
        [Obsolete]
        public string FirstItemProp { get; set; }

        [ConfigurationItem("IntValue", "ConfigurationProvider")]
        public int SecondItemProp { get; set; }

        [ConfigurationItem("FloatValue", "ConfigurationProvider")]
        public float ThirdItemProp { get; set; }

        [ConfigurationItem("TimeSpanValue", "ConfigurationProvider")]
        public TimeSpan FourthItemProp { get; set; }

        [ConfigurationItem("StringValue", "FileProvider")]
        public string FifthItemProp { get; set; }

        [ConfigurationItem("IntValue", "FileProvider")]
        public int SixthItemProp { get; set; }

        [ConfigurationItem("FloatValue", "FileProvider")]
        public float SeventhItemProp { get; set; }

        [ConfigurationItem("TimeSpanValue", "FileProvider")]
        public TimeSpan EighthItemProp { get; set; }


        public override string ToString()
        {
            StringBuilder sb = new();

            sb.AppendLine("Object to string: CustomItem");
            sb.AppendLine("ConfigProvider:");
            sb.AppendLine($"FirstItemProp: {FirstItemProp}");
            sb.AppendLine($"SecondItemProp: {SecondItemProp}");
            sb.AppendLine($"ThirdItemProp: {ThirdItemProp}");
            sb.AppendLine($"FourthItemProp: {FourthItemProp}");
            sb.AppendLine("FileProvider:");
            sb.AppendLine($"FifthItemProp: {FifthItemProp}");
            sb.AppendLine($"SixthItemProp: {SixthItemProp}");
            sb.AppendLine($"SeventhItemProp: {SeventhItemProp}");
            sb.AppendLine($"EighthItemProp: {EighthItemProp}");

            return sb.ToString();
        }
    }
}
