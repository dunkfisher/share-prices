namespace Computershare
{
    class ShareCalculatorFactory
    {
        public IShareCalculator GetShareCalculator()
        {
            return new ShareCalculator();
        }
    }
}
