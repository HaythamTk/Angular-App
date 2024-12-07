namespace Design_Patterns.Models.Behavioral.Strategy.DiscountStrategy
{
    public interface ICustomerDiscountStrategy
    {
        double CalculateDiscount(double totalPrice);
    }
}
