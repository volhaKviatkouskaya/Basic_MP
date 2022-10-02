namespace FileSystemVisitor
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var path = @"C:\FileSystem";
            FileSystem fs = new(path);
            var startFolder = fs.GetFileSystemList();

        }
    }
}

