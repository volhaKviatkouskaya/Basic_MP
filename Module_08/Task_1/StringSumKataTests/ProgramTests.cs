using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;


namespace StringSumKata.Tests
{
    [TestClass]
    public class ProgramTests
    {
        [TestMethod]

        [DataRow("1", "2", "3")]
        [DataRow("2", "2", "4")]
        [DataRow("2", "3", "5")]
        public void Returns_Sum_Of_Two_Natural_Numbers(string num1, string num2, string expected)
        {
            var actual = Program.Sum(num1, num2);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow("0", "1", "1")]
        [DataRow("-1", "1", "1")]
        public void Returns_Sum_If_One_Number_Is_Non_Natural(string num1, string num2, string expected)
        {
            var actual = Program.Sum(num1, num2);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow("1", "79228162514264337593543950335")]
        public void Should_Throw_OverflowException(string num1, string num2)
        {
            Assert.ThrowsException<OverflowException>(() => Program.Sum(num1, num2));
        }

        [TestMethod]
        [DataRow("1", "1A")]
        [DataRow("1", "1 1")]
        public void Should_Throw_FormatException(string num1, string num2)
        {
            Assert.ThrowsException<FormatException>(() => Program.Sum(num1, num2));
        }

        [TestMethod]
        [DataRow("1", null)]
        public void Should_Throw_ArgumentNullException(string num1, string num2)
        {
            Assert.ThrowsException<ArgumentNullException>(() => Program.Sum(num1, num2));
        }
    }
}