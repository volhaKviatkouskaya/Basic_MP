using System.Reflection;

namespace CustomAttribute
{
    public class CustomItemManager
    {

        public void ReturnItemProperties(Type type)
        {
            var propInfo = type.GetProperties();


            foreach (var property in propInfo)
            {
                var customAttributes = property.GetCustomAttributesData();

                if (customAttributes.Count() > 0)
                {
                    Console.WriteLine($"Property: {property.Name}");
                    Console.WriteLine("Custom attributes:");

                    foreach (var attribute in customAttributes)
                    {
                        if (attribute.AttributeType == typeof(CustomAttribute))
                        {
                            Console.WriteLine(attribute);
                        }
                    }
                }
                Console.WriteLine();
            }
        }

    }
}
