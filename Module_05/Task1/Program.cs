using System;

namespace Task1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var input = Console.ReadLine();
            try
            {
                Console.WriteLine(input[0]);
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Attempted to print empty line");
            }
        }
    }
}