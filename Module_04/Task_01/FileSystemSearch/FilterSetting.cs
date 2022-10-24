using System.CommandLine;
using System.CommandLine.Invocation;
using Console = System.Console;

namespace FileSystemSearch
{
    public static class FilterSetting
    {
        // private static List<string> CommandList = new() { "-help", "-list", "-file", "-folder", "-date",
        //       "-nameLength", "-fileType" };

        private static string FileType { get; set; }
        private static DateTime CreationDate { get; set; }
        private static int NameLength { get; set; }

        public static void PassConsoleInput(params string[] args)
        {
            var allOption = new Option<bool>(name: "--all", "Search all");
            var fileOption = new Option<bool>(name: "--file", "Search files only");
            var foldOption = new Option<bool>(name: "--folder", "Search folders only");
            var fileTypeOption = new Option<bool>(name: "--filetype", "Search file with type .type");
            var nameLengthOption = new Option<bool>(name: "--name", "Search file/folder with length name XX");

            var rootCommand = new RootCommand("CommandLine app for search");

            rootCommand.AddOption(allOption);
            rootCommand.AddOption(fileOption);
            rootCommand.AddOption(foldOption);
            rootCommand.AddOption(fileTypeOption);
            rootCommand.AddOption(nameLengthOption);

            rootCommand.SetHandler((x) =>
            {
                Handle(x);
            });
            rootCommand.Invoke(args);
        }

        public static void Handle(InvocationContext cont)
        {
            var options = cont.BindingContext.ParseResult.Tokens.FirstOrDefault().ToString();
            var filter = FilterSetting.GetFilter(options);
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

                return (ActionType)userInput;
            };

            var array = systemVisitor.Search(@"C:\FileSystem");

            Program.PrintToConsole(array);
        }

        public static Predicate<SearchedItem> GetFilter(string arg)

        {
            var userInput = arg.ToUpper();

            switch (userInput)
            {
                case "--FILE": return x => !x.IsFolder;
                case "--FOLDER": return x => x.IsFolder;
                case "--DATE":
                    return x => x.Date.Year == CreationDate.Year
                                && x.Date.Month == CreationDate.Month
                                && x.Date.Day == CreationDate.Day;
                case "--NAMELENGTH": return x => x.NameLength == NameLength;
                case "--FILETYPE": return x => x.FileType == FileType;
                default: return x => x.IsFolder || !x.IsFolder;
            }
        }
    }
}
