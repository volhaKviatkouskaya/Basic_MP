using System.Text;

namespace CustomAttribute
{
    public class CustomItem
    {
        [ConfigurationItem("FirstName", "File")]
        public string FirstItemProp { get; set; }

        [ConfigurationItem("SecondName", "File")]
        [Obsolete]
        public string SecondItemProp { get; set; }

        public string ThirdItemPropWithoutAttributes { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new();

            sb.AppendLine("Object to string: CustomItem");
            sb.AppendLine($"FirstItemProp: {FirstItemProp}");
            sb.AppendLine($"SecondItemProp: {SecondItemProp}");
            sb.AppendLine($"ThirdItemProp: {ThirdItemPropWithoutAttributes}");

            return sb.ToString();
        }
    }
}
