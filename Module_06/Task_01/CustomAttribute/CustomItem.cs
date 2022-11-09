using System.Text;

namespace CustomAttribute
{
    public class CustomItem
    {
        [ConfigurationItem("StringValue", "File")]
        [Obsolete]
        public string FirstItemProp { get; set; }

        [ConfigurationItem("IntValue", "File")]
        public int SecondItemProp { get; set; }

        [ConfigurationItem("FloatValue", "File")]
        public float ThirdItemProp { get; set; }

        [ConfigurationItem("TimeSpanValue", "File")]
        public TimeSpan FourthItemProp { get; set; }

        public string ItemPropWithoutAttributes { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new();

            sb.AppendLine("Object to string: CustomItem");
            sb.AppendLine($"FirstItemProp: {FirstItemProp}");
            sb.AppendLine($"SecondItemProp: {SecondItemProp}");
            sb.AppendLine($"ThirdItemProp: {ThirdItemProp}");
            sb.AppendLine($"FourthItemProp: {FourthItemProp}");
            sb.AppendLine($"ItemProp: {ItemPropWithoutAttributes}");

            return sb.ToString();
        }
    }
}
