using Microsoft.VisualStudio.TestTools.UnitTesting;

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
        [DataRow("1", "79228162514264337593543950335", "1")]
        [DataRow("2", "1.7976931348623157E+308", "2")]
        [DataRow("3", "3.402823466 E + 38", "3")]
        public void Returns_Sum_If_One_Number_Is_Non_Natural(string num1, string num2, string expected)
        {
            var actual = Program.Sum(num1, num2);

            Assert.AreEqual(expected, actual);
        }
    }
}