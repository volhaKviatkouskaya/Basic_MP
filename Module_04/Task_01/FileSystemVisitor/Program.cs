using System;
using System.IO;

namespace FileSystemVisitor
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var target = @"C:\FileSystem";
            FileSystem fs = new(target);
            string[] startFolder = fs.GetFileSystemList();

        }
    }
}

