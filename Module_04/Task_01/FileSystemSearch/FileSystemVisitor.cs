namespace FileSystemSearch
{
    public class FileSystemVisitor
    {
        public List<string> GetFileSystemList(string path, List<string> list)
        {
            var folderArray = Directory.GetFileSystemEntries(path);

            list.AddRange(Directory.GetFiles(path));

            foreach (var item in folderArray)
            {
                list.Add(item);
                if (Directory.Exists(item))
                {
                    var l = GetFileSystemList(item, new List<string>());
                    list.AddRange(l);
                }
            }

            return list;
        }
    }
}
