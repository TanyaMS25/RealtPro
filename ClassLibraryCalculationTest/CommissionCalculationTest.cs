using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ClassLibraryCalculation;

namespace ClassLibraryCalculationTest
{
    [TestClass]
    public class CommissionCalculationTest
    {
        [TestMethod]
        public void PositiveCalculationLessThan4Million()
        {
            double price = 3000000;
            double expected = 120000;
            double actual = CommissionCalculation.CalculationCommission(price, 0);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void PositiveCalculationLessThan8MillionMoreThanOrEqualTo4()
        {
            double price = 5000000;
            double expected = 150000;
            double actual = CommissionCalculation.CalculationCommission(price, 0);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void PositiveCalculationMoreThanOrEqualTo8Million()
        {
            double price = 9000000;
            double expected = 180000;
            double actual = CommissionCalculation.CalculationCommission(price, 0);
            Assert.AreEqual(expected, actual);
        }
    }
}
