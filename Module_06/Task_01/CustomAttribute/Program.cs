namespace CustomAttribute
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var customManager = new CustomItemManager();

            ConfigurationProviderItem configProvider = new();
            Console.WriteLine(configProvider);

            customManager.ReadFromFile(configProvider);
            Console.WriteLine(configProvider);

            configProvider.IntValue = 2345;
            customManager.WriteToFile(configProvider);

            FileProviderItem fileProvider = new();
            Console.WriteLine(fileProvider);

            customManager.ReadFromFile(fileProvider);


            ConfigurationProviderItem item2 = new();
            Console.WriteLine(item2);

            customManager.ReadFromFile(configProvider);
            Console.WriteLine(configProvider);

        }
    }
}
