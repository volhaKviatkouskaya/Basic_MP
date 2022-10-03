using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystemVisitor
{
    public class FileSystem
    {
        private readonly bool IsFindFilesEnabled;

        public FileSystem() => IsFindFilesEnabled = default;
        public FileSystem(bool isFindFilesEnabled) => IsFindFilesEnabled = isFindFilesEnabled;

        public List<string> GetFileSystemList(string path, List<string> list)
        {
            var folderArray = Directory.GetDirectories(path);

            if (IsFindFilesEnabled)
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
