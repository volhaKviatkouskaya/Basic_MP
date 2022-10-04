namespace FileSystemSearch
{
    public class FileSystemVisitor
    {
        public IEnumerable<SearchedItem> Search(string path)
        {

            foreach (var item in Directory.GetFileSystemEntries(path))
            {
                yield return Directory.Exists(item)
                            ? CreateDirItem(item)
                            : CreateFileItem(item);
            }

            foreach (var directory in Directory.GetFileSystemEntries(path))
            {
                if (Directory.Exists(directory))
                {
                    foreach (var item in Search(directory))
                    {
                        yield return item;
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
                Date = File.GetCreationTime(item)
            };
        }
    }
}
