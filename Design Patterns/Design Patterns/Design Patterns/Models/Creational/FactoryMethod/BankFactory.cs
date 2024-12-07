namespace Design_Patterns.Models.Creational.FactoryMethod
{
    public class BankFactory : IBankFactory
    {
        public Ibank GetBank(string bankCode)
        {
           switch (bankCode)
            {
                case "123456" : return new BankA();
                case "111111" : return new BankB();
                default: return null;
            }
        }
    }
}
