using System;

namespace Task2
{
    public class NumberParser : INumberParser
    {
        private const int Diff = 48;

        public int Parse(string stringValue)
        {
            CheckStringForException(stringValue);

            var length = stringValue.Length;

            var result = 0;

            for (var i = 0; i < length; i++)
            {
                if ((i == 0 && (stringValue[i] == '-' || stringValue[i] == '+'))
                    || i != 0 && char.IsWhiteSpace(stringValue[i]))
                {
                    continue;
                }

                if (char.IsNumber(stringValue[i]))
                {
                    checked
                    {
                        result *= 10;
                        _ = stringValue[0] == '-' ?
                            result -= stringValue[i] - Diff :
                            result += stringValue[i] - Diff;
                    }
                }
                else
                {
                    throw new FormatException();
                }
            }

            return result;
        }

        private void CheckStringForException(string stringValue)
        {
            if (stringValue == null)
            {
                throw new ArgumentNullException();
            }

            if (stringValue.Length == 0)
            {
                throw new FormatException();
            }
        }
    }
}