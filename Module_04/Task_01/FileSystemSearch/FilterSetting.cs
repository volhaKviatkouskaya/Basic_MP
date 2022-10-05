using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystemSearch
{
    public static class FilterSetting
    {
        public static int GetUserFilter()
        {
            Console.WriteLine("Enter filtering parameter from 1 till 5, where: \n" +
                              "1 - File \n" +
                              "2 - Folder \n" +
                              "3 - File type \n" +
                              "4 - Creation date \n" +
                              "5 - Size");

            return Convert.ToInt32(Console.ReadLine());
        }


    }
}
