using Console = System.Console;

namespace FileSystemSearch
{
    public static class FilterSetting
    {
        private static List<string> CommandList = new() { "-help", "-list", "-file", "-folder", "-date",
                                                          "-nameLength", "-fileType" };

        private static string FileType { get; set; }
        private static DateTime CreationDate { get; set; }
        private static int NameLength { get; set; }

        private static string GetUserInput()
        {
            var input = Console.ReadLine().ToUpper();
            var splitLine = input.Split(' ', '.');

            if (splitLine[0] == "-DATE")
            {
                var year = Convert.ToInt32(splitLine[1]);
                var month = Convert.ToInt32(splitLine[2]);
                var day = Convert.ToInt32(splitLine[3]);
                CreationDate = new DateTime(year, month, day);
            }

            if (splitLine[0] == "-NAMELENGTH")
                NameLength = NameLength = Convert.ToInt32(splitLine[1]);

            if (splitLine[0] == "-FILETYPE")
                FileType = $".{splitLine[2]}";

            return splitLine[0];
        }
        public static Predicate<SearchedItem> GetFilter()

        {
            var userInput = GetUserInput();
            if (userInput == "-HELP")
            {
                ShowHelp();
                userInput = GetUserInput();
            }
            switch (userInput)
            {
                case "-FILE": return x => !x.IsFolder;
                case "-FOLDER": return x => x.IsFolder;
                case "-DATE":
                    return x => x.Date.Year == CreationDate.Year
                                        && x.Date.Month == CreationDate.Month
                                        && x.Date.Day == CreationDate.Day;
                case "-NAMELENGTH": return x => x.NameLength == NameLength;
                case "-FILETYPE": return x => x.FileType == FileType;
                default: return x => x.IsFolder || !x.IsFolder;
            }
        }

        public static void ShowHelp()
        {
            foreach (var item in CommandList)
            {
                switch (item)
                {
                    case "-HELP":
                        Console.WriteLine($"{item} -> show command list ");
                        break;
                    case "-LIST":
                        Console.WriteLine($"{item} -> show all results ");
                        break;
                    case "-FILE":
                        Console.WriteLine($"{item} -> search files ");
                        break;
                    case "-FOLDER":
                        Console.WriteLine($"{item} -> search folders ");
                        break;
                    case "-DATE":
                        Console.WriteLine($"{item} -> search files/folders created in that date YYYY.MM.DD");
                        break;
                    case "-NAMELENGTH":
                        Console.WriteLine($"{item} -> search file/folders with name length of XXX");
                        break;
                    case "-FILETYPE":
                        Console.WriteLine($"{item} -> search files with type like .TXT");
                        break;
                }
            }
        }
    }
}
