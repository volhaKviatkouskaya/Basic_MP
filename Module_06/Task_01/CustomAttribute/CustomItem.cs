using System;

namespace CustomAttribute
{
    public class CustomItem
    {
        [CustomAttribute("String of the Prop")]
        public string FirstItemProp { get; set; }

        [CustomAttribute(10)]
        public int SecondItemProp { get; set; }

        public string ThirdItemPropWithoutAttributes { get; set; }
    }

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class CustomAttribute : Attribute
    {
        public CustomAttribute(string value) => SomeStringValue = value;

        public CustomAttribute(int someIntValue) => SomeIntValue = someIntValue;

        public string SomeStringValue { get; set; }

        public int SomeIntValue { get; set; }
    }
}
