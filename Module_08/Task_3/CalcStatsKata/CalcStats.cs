namespace CalcStatsKata
{
    public class CalcStats
    {
        private readonly int[] _sequence;

        public CalcStats(params int[] number)
        {
            _sequence = number;
        }

        public int GetMinNumber()
        {
            var minNumber = _sequence[0];

            foreach (var number in _sequence)
            {
                if (number < minNumber)
                {
                    minNumber = number;
                }
            }

            return minNumber;
        }

        public int GetMaxNumber()
        {
            var maxNumber = _sequence[0];

            foreach (var number in _sequence)
            {
                if (number > maxNumber)
                {
                    maxNumber = number;
                }
            }

            return maxNumber;
        }

        public int GetSequenceCount()
        {
            var count = 0;

            foreach (var number in _sequence)
            {
                count++;
            }

            return count;
        }

        public decimal GetSequenceAverage()
        {
            var count = this.GetSequenceCount();
            decimal sum = 0;

            foreach (var number in _sequence)
            {
                sum += number;
            }

            return sum / count;
        }
    }
}
