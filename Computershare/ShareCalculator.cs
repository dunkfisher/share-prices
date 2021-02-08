namespace Computershare
{
    public class ShareCalculator : IShareCalculator
    {
        public void CalculateBestBuySellDays(decimal[] dailyPrices, out int dayToBuy, out int dayToSell)
        {
            var maxProfit = 0m;
            dayToBuy = 0;
            dayToSell = 0;

            if (dailyPrices == null || dailyPrices.Length == 0)
            {
                return;
            }

            for (var i = 0; i < dailyPrices.Length; i++)
            {
                for (var j = i + 1; j < dailyPrices.Length; j++)
                {
                    var profit = dailyPrices[j] - dailyPrices[i];
                    if (profit > maxProfit)
                    {
                        maxProfit = profit;
                        dayToBuy = i;
                        dayToSell = j;
                    }
                }
            }
        }
    }
}
