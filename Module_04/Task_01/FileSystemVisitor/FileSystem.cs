using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystemVisitor
{
    public class FileSystem
    {
        private List<string> FolderList;

        public FileSystem(string path)
        {
            FolderList = Directory.GetFileSystemEntries(path).ToList();
        }


        public List<string> GetFileSystemList()
        {
            PrintFolderEntries(FolderList);

            foreach (var item in FolderList)
            {
                if (Directory.Exists(item))
                {
                    var fs = new FileSystem(item);
                    var files = fs.GetFileSystemList();
                }
            }
            return FolderList;
        }

        public void PrintFolderEntries(List<string> folderArray)
        {
            Console.WriteLine();
            foreach (var item in folderArray)
            {
                Console.WriteLine(item);
            }
        }
    }
}
