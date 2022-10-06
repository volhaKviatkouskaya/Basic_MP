namespace FileSystemSearch
{
    public static class Program
    {

        public delegate void SearchStarted();
        public static event SearchStarted StartedNotify;

        delegate void SearchCompleted();
        private static event SearchCompleted CompletedNotify;

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
            var filter = FilterSetting.GetFilter();

            StartedNotify += FileSystemVisitor_StartedNotify;
            StartedNotify?.Invoke();

            FileSystemVisitor systemVisitor = new(filter);
            var array = systemVisitor.Search(@"C:\FileSystem");
            PrintToConsole(array);

            CompletedNotify += Program_CompletedNotify;
            CompletedNotify.Invoke();
        }

        private static void Program_CompletedNotify()
        {
            Console.WriteLine("Search finished");
        }

        private static void FileSystemVisitor_StartedNotify()
        {
            Console.WriteLine("Search started!");
        }
    }
}
