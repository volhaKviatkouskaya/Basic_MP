using System;

namespace StringSumKata
{
    public class Program
    {
        public static void Main(string[] args) { }

        public static string Sum(string num1, string num2)
        {
            CheckNumber(num1);
            CheckNumber(num2);

            var firstNum = int.Parse(num1);
            var secondNum = int.Parse(num2);

            firstNum = firstNum <= 0 ? 0 : firstNum;
            secondNum = secondNum <= 0 ? 0 : secondNum;

            return (firstNum + secondNum).ToString();
        }

        public static void CheckNumber(string inputString)
        {
            if (inputString == null)
            {
                throw new ArgumentNullException();
            }

            if (inputString.Length == 0)
            {
                throw new FormatException();
            }

            if (inputString.Any(sign => char.IsLetter(sign) || char.IsWhiteSpace(sign)))
            {
                throw new FormatException();
            }
        }
    }
}
