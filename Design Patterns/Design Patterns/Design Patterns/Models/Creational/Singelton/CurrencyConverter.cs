namespace Design_Patterns.Models.Creational.Singelton
{
    public class CurrencyConverter
    {
        private IEnumerable<ExchangeRate> _exchangeRates;

        //start singelton
        //make the constructor private
        //make method name instance and in this and check if instance null or no if null create instance 
        private CurrencyConverter()
        {
            LoadExchangeRates();
        }
        private static object _lock = new();
        private static CurrencyConverter _instance;
        public static CurrencyConverter Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                        _instance = new();
                }
                return _instance;
            }
        }
        ////end singelton
        private void LoadExchangeRates()
        {
            //var v = new List<Test>
            //{
            //    new Test { Number = 5, Name = "test" },
            //    new Test { Number = 5, Name = "test" },
            //    new Test { Number = 5, Name = "test" },
            //};
            _exchangeRates = new[]
            {
                new ExchangeRate("JD","USD",1.3),
                new ExchangeRate("USD","JD",0.7),
            };
        }

        public double Convert(string baseCurrency, string targetCurrency, double amount)
        {
            var exchangeRate = _exchangeRates.FirstOrDefault(x => x.BaseCurrency == baseCurrency && x.TargetCurrency == targetCurrency);
            return exchangeRate.Rate * amount;
        }
    }
}
