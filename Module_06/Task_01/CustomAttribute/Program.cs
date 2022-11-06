namespace CustomAttribute
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var customManager = new CustomItemManager();

            CustomItem item = new();
            Console.WriteLine(item);

            customManager.SetItemProperties(item);
            Console.WriteLine(item);
        }
    }
}
