namespace FileSystemSearch
{
    public class FileSystemVisitor
    {
        public Predicate<SearchedItem> Predicate;
        public FileSystemVisitor() { }

        public FileSystemVisitor(Predicate<SearchedItem> predicate) => Predicate = predicate;

        public IEnumerable<SearchedItem> Search(string path)
        {
            foreach (var item in Directory.GetFileSystemEntries(path))
            {
                if (Directory.Exists(item))
                {
                    var folder = CreateDirItem(item);
                    if (Predicate(folder)) yield return folder;
                }
                else
                {
                    var file = CreateFileItem(item);
                    if (Predicate(file)) yield return file;
                }
            }

            foreach (var directory in Directory.GetFileSystemEntries(path))
            {
                if (Directory.Exists(directory))
                {
                    foreach (var item in Search(directory))
                    {
                        if (Predicate(item)) yield return item;
                    }
                }
            }
        }

        private SearchedItem CreateDirItem(string item)
        {
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
