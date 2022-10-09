namespace FileSystemSearch
{
    public class FileSystemVisitor
    {
        public Predicate<SearchedItem> Predicate;
        public FileSystemVisitor() { }

        public FileSystemVisitor(Predicate<SearchedItem> predicate) => Predicate = predicate;

        public List<SearchedItem> Search(string path)
        {
            Action startNotification = SendStartedNotification;
            startNotification();

            var result = SearchRecursive(path).ToList();

            Action finishNotification = SendFinishedNotification;
            finishNotification();

            return result;
        }

        public IEnumerable<SearchedItem> SearchRecursive(string path)
        {
            foreach (var item in Directory.GetFileSystemEntries(path))
            {
                if (Directory.Exists(item))
                {
                    var folder = CreateDirItem(item);
                    if (Predicate(folder))
                    {
                        Action<string> filteredDir = SendFilteredFoundDirectory;
                        filteredDir(folder.Name);

                        yield return folder;
                    }
                }
                else
                {
                    var file = CreateFileItem(item);
                    if (Predicate(file))
                    {
                        Action<string> filteredFile = SendFilteredFoundFile;
                        filteredFile(file.Name);

                        yield return file;
                    }
                }
            }

            foreach (var directory in Directory.GetFileSystemEntries(path))
            {
                if (Directory.Exists(directory))
                {
                    foreach (var item in SearchRecursive(directory))
                    {
                        if (Predicate(item)) yield return item;
                    }
                }
            }
        }

        private SearchedItem CreateDirItem(string item)
        {
            Action<string> directoryNotification = SendFoundDirectory;
            directoryNotification(item);

            return new SearchedItem()
            {
                Name = item,
                IsFolder = Directory.Exists(item),
                NameLength = Path.GetDirectoryName(item).Length,
                Date = Directory.GetCreationTime(item)
            };
        }

        private SearchedItem CreateFileItem(string item)
        {
            Action<string> fileNotification = SendFoundFile;
            fileNotification(item);

            return new SearchedItem()
            {
                Name = item,
                IsFolder = Directory.Exists(item),
                NameLength = Path.GetFileName(item).Length,
                FileType = new FileInfo(item).Extension,
                Date = File.GetCreationTime(item)
            };
        }

        private static void SendStartedNotification()
        {
            Console.WriteLine("Search started!");
        }

        private static void SendFinishedNotification()
        {
            Console.WriteLine("Search finished!");
        }

        private static void SendFoundDirectory(string dirName)
        {
            Console.WriteLine($"Directory found: {dirName}");
        }

        private static void SendFoundFile(string fileName)
        {
            Console.WriteLine($"File found: {fileName}");
        }

        private static void SendFilteredFoundDirectory(string dirName)
        {
            Console.WriteLine($"Filtered directory found: {dirName}");
        }

        private static void SendFilteredFoundFile(string fileName)
        {
            Console.WriteLine($"Filtered file found: {fileName}");
        }
    }
}
