using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystemVisitor
{
    public class FileSystem
    {
        private readonly string Path;

        public FileSystem(string path)
        {
            Path = path;
        }

        public string[] GetFileSystemList()
        {
            string[] folderArray = Directory.GetFileSystemEntries(Path);
            PrintFolderEntries(folderArray);

            foreach (var item in folderArray)
            {
                if (Directory.Exists(item))
                {
                    FileSystem fs = new FileSystem(item);
                    string[] files = fs.GetFileSystemList();
                }
            }
            return folderArray;
        }

        public void PrintFolderEntries(string[] folderArray)
        {
            Console.WriteLine();
            foreach (var item in folderArray)
            {
                Console.WriteLine(item);
            }
        }
    }
}
