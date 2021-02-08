using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Computershare.Tests
{
    [TestClass]
    public class ShareCalculatorTests
    {
        [TestMethod]
        public void CalculateBestBuySellDays_DailyPricesNull_DaysAreZero()
        {
            int buyDay, sellDay;
            var calculator = new ShareCalculator();

            calculator.CalculateBestBuySellDays(null, out buyDay, out sellDay);

            Assert.AreEqual(0, buyDay);
            Assert.AreEqual(0, sellDay);
        }

        [TestMethod]
        public void CalculateBestBuySellDays_SinglePrice_DaysAreZero()
        {
            int buyDay, sellDay;
            var calculator = new ShareCalculator();

            calculator.CalculateBestBuySellDays(ConvertCsvToNumbers("10.0"), out buyDay, out sellDay);

            Assert.AreEqual(0, buyDay);
            Assert.AreEqual(0, sellDay);
        }

        [TestMethod]
        public void CalculateBestBuySellDays_TwoPrices_DaysAreZeroAndOne()
        {
            int buyDay, sellDay;
            var calculator = new ShareCalculator();

            calculator.CalculateBestBuySellDays(ConvertCsvToNumbers("10.0,15.0"), out buyDay, out sellDay);

            Assert.AreEqual(0, buyDay);
            Assert.AreEqual(1, sellDay);
        }

        [TestMethod]
        public void CalculateBestBuySellDays_LargeDatasetOne_DaysAsExpected()
        {
            int buyDay, sellDay;
            var calculator = new ShareCalculator();

            calculator.CalculateBestBuySellDays(ConvertCsvToNumbers("18.93,20.25,17.05,16.59,21.09,16.22,21.43,27.13,18.62,21.31,23.96,25.52,19.64,23.49,15.28,22.77,23.1,26.58,27.03,23.75,27.39,15.93,17.83,18.82,21.56,25.33,25,19.33,22.08,24.03"),
                out buyDay, out sellDay);

            Assert.AreEqual(14, buyDay);
            Assert.AreEqual(20, sellDay);
        }

        [TestMethod]
        public void CalculateBestBuySellDays_LargeDatasetTwo_DaysAsExpected()
        {
            int buyDay, sellDay;
            var calculator = new ShareCalculator();

            calculator.CalculateBestBuySellDays(ConvertCsvToNumbers("22.74,22.27,20.61,26.15,21.68,21.51,19.66,24.11,20.63,20.96,26.56,26.67,26.02,27.20,19.13,16.57,26.71,25.91,17.51,15.79,26.19,18.57,19.03,19.02,19.97,19.04,21.06,25.94,17.03,15.61"),
                out buyDay, out sellDay);

            Assert.AreEqual(19, buyDay);
            Assert.AreEqual(20, sellDay);
        }

        private decimal[] ConvertCsvToNumbers(string pricesCsv)
        {
            var dailyPrices = pricesCsv.Split(',');
            return Array.ConvertAll(dailyPrices, Convert.ToDecimal);
        }
    }
}
