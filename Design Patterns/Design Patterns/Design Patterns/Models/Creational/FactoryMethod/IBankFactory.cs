namespace Design_Patterns.Models.Creational.FactoryMethod
{
    public interface IBankFactory
    {
        Ibank GetBank(string bankCode);
    }
}
