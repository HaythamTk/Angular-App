namespace Design_Patterns.Models.Creational.Singelton
{
    public class ExchangeRate
    {
        public ExchangeRate(string baseCurrency, string targetCurrency, double rate)
        {
            BaseCurrency = baseCurrency;
            TargetCurrency = targetCurrency;
            Rate = rate;
        }
        public string BaseCurrency { get; }
        public string TargetCurrency { get; }
        public double Rate { get; }
    }
}
