using System;

namespace Task2
{
    public class NumberParser : INumberParser
    {
        public int Parse(string stringValue)
        {
            if (stringValue == null)
            {
                throw new ArgumentNullException();
            }

            int number;
            try
            {
                number = Convert.ToInt32(stringValue);
            }
            catch (FormatException)
            {
                throw new FormatException();
            }
            return number;
        }
    }
}