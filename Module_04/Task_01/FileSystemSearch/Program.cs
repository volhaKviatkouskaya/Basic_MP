using System;
using System.CommandLine;
using System.CommandLine.Builder;
using System.CommandLine.Invocation;
using System.CommandLine.Parsing;

namespace FileSystemSearch
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            FilterSetting.PassConsoleInput(args);
            /*
            var allOption = new Option<bool>(name: "--all", "Select all");
            var foldOption = new Option<bool>(name: "--folder", "Exclude folders from search");

            var rootCommand = new RootCommand("CommandLine app for search");
            rootCommand.AddOption(allOption);
            rootCommand.AddOption(foldOption);

            rootCommand.SetHandler((x) =>
            {
                Handle(x);
            });
            rootCommand.Invoke(args);

            /*
            var infinitySearch = true;
            do
            {
                var filter = FilterSetting.GetFilter();
                FileSystemVisitor systemVisitor = new(filter);

                systemVisitor.StartEvent += () => Console.WriteLine("Search started!");
                systemVisitor.FinishEvent += () => Console.WriteLine("Search finished!");

                systemVisitor.FoundItem += (x) =>
                {
                    var itemType = x.IsFolder ? "Directory" : "File";
                    Console.WriteLine($"{itemType}  found: {x.Name}");
                };

                systemVisitor.FoundFilteredItem += (x) =>
                {
                    var itemType = x.IsFolder ? "directory" : "file";
                    Console.WriteLine($"Filtered {itemType} found: {x.Name}");
                    Console.WriteLine("Exclude item(1), Keep item(2), Abort search(3)?");
                    var userInput = Convert.ToInt32(Console.ReadLine());
                    if (userInput == (int)ActionType.AbortSearch)
                        infinitySearch = false;
                    return (ActionType)userInput;
                };

                var array = systemVisitor.Search(@"C:\FileSystem");

                if (infinitySearch) PrintToConsole(array);

            } while (infinitySearch);
            */
        }
        public static void PrintToConsole(IEnumerable<SearchedItem> array)
        {
            Console.WriteLine("Search result:");
            foreach (var item in array)
            {
                Console.WriteLine(item);
            }
        }
    }
}
