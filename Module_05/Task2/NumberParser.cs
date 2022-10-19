using System;

namespace Task2
{
    public class NumberParser : INumberParser
    {
        public int Parse(string stringValue)
        {
            if (stringValue == null) throw new ArgumentNullException();

            var length = stringValue.Length;

            if (length == 0) throw new FormatException();

            int result = 0;

            for (int i = 0; i < length; i++)
            {
                if ((stringValue[i] == '-' || stringValue[i] == '+') && i == 0)
                    continue;

                if (i != 0 && char.IsWhiteSpace(stringValue[i]))
                    continue;

                if (char.IsNumber(stringValue[i]))
                {
                    result *= 10;
                    result += ((int)stringValue[i] - 48);
                }

                else
                    throw new FormatException();
            }

            if (stringValue[0] == '-')
                result *= -1;

            return result;
        }
    }
}