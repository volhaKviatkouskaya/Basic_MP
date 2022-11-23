namespace CustomAttribute
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var customManager = new CustomItemManager();

            Console.WriteLine("Using Configuration Provider");
            ConfigurationProviderItem configProvider = new();
            Console.WriteLine(configProvider);
            customManager.ReadFromFile(configProvider);
            Console.WriteLine(configProvider);

            configProvider.IntValue = 2345;
            configProvider.FloatValue = float.Epsilon;
            configProvider.StringValue = "some string";
            configProvider.TimeSpanValue = TimeSpan.MinValue;
            customManager.WriteToFile(configProvider);
            customManager.ReadFromFile(configProvider);
            Console.WriteLine(configProvider);

            Console.WriteLine("Using Configuration Provider");
            FileProviderItem fileProvider = new();
            Console.WriteLine(fileProvider);
            customManager.ReadFromFile(fileProvider);
            Console.WriteLine(customManager);

            fileProvider.IntValue = 2345;
            fileProvider.FloatValue = float.Epsilon;
            fileProvider.StringValue = "some string";
            fileProvider.TimeSpanValue = TimeSpan.MinValue;
            customManager.WriteToFile(fileProvider);
            customManager.ReadFromFile(fileProvider);
            Console.WriteLine(fileProvider);

            customManager.ReadFromFile(fileProvider);
            Console.WriteLine(fileProvider);

        }
    }
}
