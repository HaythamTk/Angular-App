namespace Design_Patterns.Models.Behavioral.Strategy.DiscountStrategy
{
    public class GoldCustomer : ICustomerDiscountStrategy
    {
        public double CalculateDiscount(double totalPrice)
        {
            return totalPrice >= 10000 ? 0.1 : 0;
        }
    }
}
