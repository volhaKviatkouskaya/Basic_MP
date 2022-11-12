namespace CustomAttribute
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var customManager = new CustomItemManager();

            CustomItem item = new();
            Console.WriteLine(item);

            customManager.ReadFromFile(item);
            Console.WriteLine(item);


            item.FifthItemProp = "newwwwww";
            item.SixthItemProp = 13;
            customManager.WriteToFile(item);

            CustomItem item2 = new();
            Console.WriteLine(item2);

            customManager.ReadFromFile(item);
            Console.WriteLine(item);
        }
    }
}
