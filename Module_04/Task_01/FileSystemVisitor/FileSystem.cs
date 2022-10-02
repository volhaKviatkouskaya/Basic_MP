using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystemVisitor
{
    public class FileSystem
    {
        public List<string> FolderList;

        public FileSystem(string path)
        {
            FolderList = new List<string>();
            GetFileSystemList(path);
        }

        public void GetFileSystemList(string path)
        {
            var folderArray = Directory.GetFileSystemEntries(path);

            foreach (var item in folderArray)
            {
                if (Directory.Exists(item))
                {
                    GetFileSystemList(item);
                }
                FolderList.Add(item);
            }
        }

    }
}
