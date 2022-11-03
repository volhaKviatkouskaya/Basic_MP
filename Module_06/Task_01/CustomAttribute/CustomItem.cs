namespace CustomAttribute
{
    public class CustomItem
    {
        [Custom(Name = "NameProp")]
        public string NameProp { get; set; }

        [Custom(Value = "ValueValue")]
        public string ValueProp { get; set; }

        public CustomItem(string nameProp, string valueProp)
        {
            NameProp = nameProp;
            ValueProp = valueProp;
        }
    }

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class CustomAttribute : Attribute
    {
        public string Name { set; get; }
        public string Value { set; get; }
    }
}
