using Microsoft.VisualStudio.TestTools.UnitTesting;
using CalcStatsKata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcStatsKata.Tests
{
    [TestClass]
    public class CalcStatsTests
    {
        [TestMethod]
        [DataRow(-2, 6, 9, 15, -2, 92, 11)]
        public void Get_Min_Number(int expected, params int[] numArray)
        {
            CalcStats calc = new(numArray);

            var actual = calc.GetMinNumber();

            Assert.AreEqual(expected, actual);
        }

    }
}