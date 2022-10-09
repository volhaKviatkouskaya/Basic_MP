namespace FileSystemSearch
{
    public class FileSystemVisitor
    {
        public event Action StartEvent;
        public event Action FinishEvent;

        public event Action<string> FoundItem;

        public event Func<SearchedItem, bool> FoundFilteredItem;

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
                        var res = FoundFilteredItem(folder);
                        if (res)
                        {
                            yield return folder;
                        }
                    }
                }
                else
                {
                    var file = CreateFileItem(item);
                    if (Predicate(file))
                    {
                        var res = FoundFilteredItem(file);
                        if (res)
                        {
                            yield return file;
                        }
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
            FoundItem(item);

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
            FoundItem(item);

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
