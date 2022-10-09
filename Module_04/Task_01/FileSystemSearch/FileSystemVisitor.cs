namespace FileSystemSearch
{
    public class FileSystemVisitor
    {
        public event Action StartEvent;
        public event Action FinishEvent;

        public event Action<string> FoundDir;
        public event Action<string> FoundFile;

        public event Action<SearchedItem> FoundFilteredDir;
        public event Action<SearchedItem> FoundFilteredFile;



        public Predicate<SearchedItem> Predicate;
        public FileSystemVisitor() { }

        public FileSystemVisitor(Predicate<SearchedItem> predicate) => Predicate = predicate;

        public List<SearchedItem> Search(string path)
        {
            StartEvent();
            var result = SearchRecursive(path).ToList();
            FinishEvent();
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
                        FoundFilteredDir(folder);
                        yield return folder;
                    }
                }
                else
                {
                    var file = CreateFileItem(item);
                    if (Predicate(file))
                    {
                        FoundFilteredFile(file);
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
            FoundDir(item);

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
            FoundFile(item);

            return new SearchedItem()
            {
                Name = item,
                IsFolder = Directory.Exists(item),
                NameLength = Path.GetFileName(item).Length,
                FileType = new FileInfo(item).Extension,
                Date = File.GetCreationTime(item)
            };
        }
    }
}
