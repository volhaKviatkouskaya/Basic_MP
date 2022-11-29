using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalcStatsKata.Tests
{
    [TestClass]
    public class CalcStatsTests
    {
        [TestMethod]
        [DataRow(-2, 6, 9, 15, -2, 92, 11)]
        public void Return_Min_Number(int expected, params int[] numArray)
        {
            CalcStats calc = new(numArray);

            var actual = calc.GetMinNumber();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(92, 6, 9, 15, -2, 92, 11)]
        public void Return_Max_Number(int expected, params int[] numArray)
        {
            CalcStats calc = new(numArray);

            var actual = calc.GetMaxNumber();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(6, 6, 9, 15, -2, 92, 11)]
        public void Return_Sequence_Count(int expected, params int[] numArray)
        {
            CalcStats calc = new(numArray);

            var actual = calc.GetSequenceCount();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(21.833333333333332, 6, 9, 15, -2, 92, 11)]
        public void Return_Sequence_Average(double expected, params int[] numArray)
        {
            CalcStats calc = new(numArray);

            var actual = calc.GetSequenceAverage();

            Assert.AreEqual(expected, actual);
        }
    }
}