namespace Design_Patterns.Models.Behavioral.Strategy.DiscountStrategy
{
    public class NewCustomer : ICustomerDiscountStrategy
    {
        public double CalculateDiscount(double totalPrice)
        {
            return totalPrice >= 10000 ? 0.2 : 0;
        }
    }
}
