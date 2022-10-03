using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystemVisitor
{
    public class FileSystem
    {
        public List<string> GetFileSystemList(string path, List<string> list)
        {
            var folderArray = Directory.GetFileSystemEntries(path);

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
