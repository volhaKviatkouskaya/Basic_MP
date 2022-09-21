using HelloLibrary;

namespace Module_2_1_ConsoleApp_Net_Core
{
    class Program
    {
        public static void Main(string[] args)
        {
            foreach (var parameter in args)
            {
                var output = StringLibrary.ConcatenateString(parameter);
                Console.WriteLine(output);
            }
        }
    }
}