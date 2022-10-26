namespace FileSystemSearch
{
    public static class Program
    {
        public static void Main()
        {
            var infinity = true;
            do
            {
                var args = Console.ReadLine().Split(' ');

                FilterSetting filterSetting = new((path, filterPredicate) =>
                {
                    FileSystemVisitor systemVisitor = new(filterPredicate);

                    systemVisitor.StartEvent += () => PrintToConsole("Search started!");
                    systemVisitor.FinishEvent += () => PrintToConsole("Search finished!");

                    systemVisitor.FoundItem += (x) =>
                    {
                        var itemType = x.IsFolder ? "Directory" : "File";
                        PrintToConsole($"{itemType}  found: {x.Name}");
                    };

                    systemVisitor.FoundFilteredItem += (x) =>
                    {
                        var itemType = x.IsFolder ? "directory" : "file";

                        PrintToConsole($"Filtered {itemType} found: {x.Name}");
                        PrintToConsole("Exclude item(1), Keep item(2), Abort search(3)?");

                        var userInput = Convert.ToInt32(Console.ReadLine());
                        if (userInput == (int)ActionType.AbortSearch)
                            infinity = false;

                        return (ActionType)userInput;
                    };

                    var array = systemVisitor.Search(path);

                    PrintToConsole(array);
                });

                filterSetting.PassConsoleInput(args);

            } while (infinity);
        }

        public static void PrintToConsole(IEnumerable<SearchedItem> array)
        {
            Console.WriteLine("Search result:");
            foreach (var item in array)
            {
                Console.WriteLine(item);
            }
        }

        public static void PrintToConsole(string message) => Console.WriteLine(message);
    }
}
