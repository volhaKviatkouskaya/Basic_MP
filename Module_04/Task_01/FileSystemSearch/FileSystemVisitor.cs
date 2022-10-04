namespace FileSystemSearch
{
    public class FileSystemVisitor
    {
        public IEnumerable<string> Search(string path)
        {

            foreach (var item in Directory.GetFileSystemEntries(path))
            {
                yield return item;
            }

            foreach (var directory in Directory.GetFileSystemEntries(path))
            {
                if (Directory.Exists(directory))
                {
                    foreach (var file in Search(directory))
                    {
                        yield return file;
                    }
                }
            }
        }
    }
}
