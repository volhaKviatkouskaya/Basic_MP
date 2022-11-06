using System.Reflection;

namespace CustomAttribute
{
    public class CustomItemManager
    {
        public Dictionary<string, CustomAttributeData> ReturnItemProperties(Type type)
        {
            var propInfo = type.GetProperties();
            Dictionary<string, CustomAttributeData> pairs = new();

            foreach (var property in propInfo)
            {
                var customAttributes = property.GetCustomAttributesData();

                if (customAttributes.Any())
                {
                    foreach (var attribute in customAttributes)
                    {
                        if (attribute.AttributeType == typeof(CustomAttribute))
                        {
                            pairs.Add(property.Name, attribute);
                        }
                    }
                }
            }

            return pairs;
        }

    }
}
