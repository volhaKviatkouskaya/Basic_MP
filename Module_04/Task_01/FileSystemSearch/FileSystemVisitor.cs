using System.IO;

namespace FileSystemSearch
{
    public enum ActionType
    {
        ExcludeItem = 1,
        KeepItem = 2,
        AbortSearch = 3
    }

    public class FileSystemVisitor
    {
        public event Action StartEvent;
        public event Action FinishEvent;

        public event Action<SearchedItem> FoundItem;

        public event Func<SearchedItem, ActionType> FoundFilteredItem;

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
                var foundItem = CreateItem(item);
                FoundItem(foundItem);

                if (Predicate(foundItem))
                {
                    var res = FoundFilteredItem(foundItem);

                    if (res == ActionType.ExcludeItem) continue;
                    if (res == ActionType.KeepItem) yield return foundItem;
                    if (res == ActionType.AbortSearch) yield break;
                }

                if (foundItem.IsFolder)
                {
                    foreach (var foundInDir in SearchRecursive(foundItem.Name))
                    {
                        if (Predicate(foundInDir)) yield return foundInDir;
                    }
                }
            }
        }

        private SearchedItem CreateItem(string item)
        {
            var isDirExist = Directory.Exists(item);

            if (isDirExist)
            {
                return new SearchedItem()
                {
                    Name = item,
                    IsFolder = isDirExist,
                    NameLength = Path.GetDirectoryName(item).Length,
                    Date = Directory.GetCreationTime(item)
                };
            }
            else
            {
                return new SearchedItem()
                {
                    Name = item,
                    IsFolder = isDirExist,
                    NameLength = Path.GetFileName(item).Length,
                    FileType = new FileInfo(item).Extension.ToUpper(),
                    Date = File.GetCreationTime(item)
                };
            }
        }
    }
}