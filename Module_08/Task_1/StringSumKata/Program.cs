using System;

namespace StringSumKata
{
    public class Program
    {
        public static void Main(string[] args)
        {

        }

        public string Sum(string num1, string num2)
        {
            var firstNum = int.Parse(num1);
            var secondNum = int.Parse(num2);

            return (firstNum + secondNum).ToString();
        }
    }
}
