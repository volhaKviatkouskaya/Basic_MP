using CustomAttribute;

namespace CustomProgram
{
    public class Program
    {
        public static void Main(string[] args)
        {

            string[] pathString = new string[]
            {
                "C:\\Users\\Volha_Kviatkouskaya\\source\\repos\\Basic_MP\\Module_06\\Task_02\\Plugins\\AppConfigurationProvider.dll",
                "C:\\Users\\Volha_Kviatkouskaya\\source\\repos\\Basic_MP\\Module_06\\Task_02\\Plugins\\JsonFileProvider.dll"
            };

            var customManager = new CustomItemManager(pathString);

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
