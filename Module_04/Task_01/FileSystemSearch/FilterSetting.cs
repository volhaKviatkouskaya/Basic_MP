using System.CommandLine;

namespace FileSystemSearch
{
    public class FilterSetting
    {
        private Action<string, Predicate<SearchedItem>> filtersPredicate;
        public FilterSetting(Action<string, Predicate<SearchedItem>> predicate) => filtersPredicate = predicate;

        public void PassConsoleInput(params string[] args)
        {
            var filterOption = new Option<string>(name: "--filter", "Filter: filter, filterValue");
            var filterValueOption = new Option<string>(name: "--filter-value", "Filter value: filterValue type, date:DD.MM.YYYY");

            var pathArgument = new Argument<string>(
                name: "path",
                description: "Path for search");

            var rootCommand = new RootCommand("CommandLine app for search");

            rootCommand.AddOption(filterOption);
            rootCommand.AddOption(filterValueOption);
            rootCommand.AddArgument(pathArgument);
            rootCommand.SetHandler(GetAdaptation, pathArgument, filterOption, filterValueOption);


            rootCommand.Invoke(args);
        }

        public void GetAdaptation(string path, string filter, string filterValue)
        {
            filtersPredicate(path, GetFilter(filter, filterValue));
        }

        public Predicate<SearchedItem> GetFilter(string filter, string filterValue)
        {
            var userInput = filter?.ToUpper();

            switch (userInput)
            {
                case "FILE": return x => !x.IsFolder;
                case "FOLDER": return x => x.IsFolder;
                case "DATE":
                    return x => matchesDate(x.Date.Date, filterValue);
                case "LENGTH": return x => x.NameLength == Convert.ToInt32(filterValue);
                case "FILETYPE":
                    return x => x.FileType == filterValue.ToUpper();
                default: return x => x.IsFolder || !x.IsFolder;
            }
        }

        private bool matchesDate(DateTime x, string userInput)
        {
            var date = DateTime.ParseExact(userInput, "dd.MM.yyyy", null);
            return x == date;
        }
    }
}
