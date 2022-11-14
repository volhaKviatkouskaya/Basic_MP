using AppConfigurationProvider;
using CustomAttribute;
using JsonFileProvider;

namespace CustomProgram
{
    public class Program
    {
        public static Dictionary<string, object> ProviderDictionary;
        public static void Main(string[] args)
        {
            var providers = ProviderConstructor.ReturnProviders();
            
            var confProvider = new ConfigurationProvider();
            var fileProvider = new FileProvider();

            var customManager = new CustomItemManager(confProvider, fileProvider);

            CustomItem item = new();
            Console.WriteLine(item);

            customManager.ReadFromFile(item);
            Console.WriteLine(item);

            item.SecondItemProp = 2345;
            item.FifthItemProp = "set new string to json";
            item.SixthItemProp = 222222222;
            customManager.WriteToFile(item);

            CustomItem item2 = new();
            Console.WriteLine(item2);

            customManager.ReadFromFile(item);
            Console.WriteLine(item);
        }
    }
}
