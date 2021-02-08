using System;

namespace Computershare
{
    class Program
    {       
        static void Main(string[] args)
        {
            decimal[] dailyPrices;
            if (!ValidateInput(args, out dailyPrices))
            {
                Environment.Exit(1);
            }

            int dayToBuy, dayToSell;
            var shareCalculator = new ShareCalculatorFactory().GetShareCalculator();
            shareCalculator.CalculateBestBuySellDays(dailyPrices, out dayToBuy, out dayToSell);

            Console.WriteLine($"{dayToBuy + 1}({dailyPrices[dayToBuy]}),{dayToSell + 1}({dailyPrices[dayToSell]})");
            Console.ReadKey();
        }

        static bool ValidateInput(string[] args, out decimal[] monthPrices)
        {
            const int NUM_DAYS = 30;

            monthPrices = null;

            if (args == null || args.Length != 1)
            {
                return false;
            }

            var dailyPrices = args[0].Split(',');
            if (dailyPrices.Length != NUM_DAYS)
            {
                return false;
            }

            monthPrices = Array.ConvertAll(dailyPrices, Convert.ToDecimal);
            return true;
        }
    }
}
