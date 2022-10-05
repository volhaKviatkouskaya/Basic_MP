namespace FileSystemSearch
{
    public static class Program
    {
        public static void PrintToConsole(IEnumerable<SearchedItem> array)
        {
            Console.WriteLine("Search result:");
            foreach (var item in array)
            {
                Console.WriteLine(item);
            }
        }

        public static void Main(string[] args)
        {
            Console.WriteLine();
            var filterInput = FilterSetting.GetUserFilter();

            Predicate<SearchedItem> predicate = item => item.IsFolder;

            FileSystemVisitor systemVisitor = new(predicate);
            var array = systemVisitor.Search(@"C:\FileSystem");
            PrintToConsole(array);
        }
    }
}
