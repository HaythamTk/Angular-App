using Design_Patterns.Models.Behavioral.Strategy;
using Design_Patterns.Models.Behavioral.Strategy.DiscountStrategy;

namespace Design_Patterns.Models.Creational.SimpleFactory
{
    public class CustomerDiscountSimpleFactory
    {
        public ICustomerDiscountStrategy CreateCustomerDiscountStrategy(string category)
        {
            if (category == "Gold")
                return new GoldCustomer();
            else
                return new NewCustomer();
        }
    }
}
