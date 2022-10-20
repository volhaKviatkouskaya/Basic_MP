using System;

namespace Task2
{
    public class NumberParser : INumberParser
    {
        private const int Diff = 48;
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
                    checked
                    {
                        if (stringValue[0] == '-')
                        {
                            result *= 10;
                            result -= ((int)stringValue[i] - Diff);
                        }
                        else
                        {
                            result *= 10;
                            result += ((int)stringValue[i] - Diff);
                        }
                    }
                }
                else
                    throw new FormatException();
            }

            return result;
        }
    }
}