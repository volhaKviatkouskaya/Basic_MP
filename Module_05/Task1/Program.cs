using System;

namespace Task1
{
    internal class Program
    {
        private const string message = "Attempted to print empty line";

        private static void Main(string[] args)
        {
            var input = Console.ReadLine();
            try
            {
                Console.WriteLine(input[0]);
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine(message);
            }
        }
    }
}