namespace Computershare
{
    interface IShareCalculator
    {
        void CalculateBestBuySellDays(decimal[] dailyPrices, out int dayToBuy, out int dayToSell);
    }
}
