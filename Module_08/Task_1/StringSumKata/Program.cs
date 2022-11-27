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

            if (firstNum <= 0)
            {
                firstNum = 0;
            }

            if (secondNum <= 0)
            {
                secondNum = 0;
            }

            return (firstNum + secondNum).ToString();
        }

        public static void CheckNumber(string number)
        {
            if (number == null)
            {
                throw new ArgumentNullException();
            }

            if (number.Length == 0)
            {
                throw new FormatException();
            }

            if (number.Any(sign => char.IsLetter(sign) || char.IsWhiteSpace(sign)))
            {
                throw new FormatException();
            }
        }
    }
}
