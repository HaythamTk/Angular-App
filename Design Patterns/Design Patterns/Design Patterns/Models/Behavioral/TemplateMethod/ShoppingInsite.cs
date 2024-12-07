namespace Design_Patterns.Models.Behavioral.Template
{
    public class ShoppingInsite : ShoppingCart
    {
        public override double ApplyDiscount(double invoiceValue)
        {
           if (invoiceValue > 100)
              return  invoiceValue * 0;

           return invoiceValue;
        }
    }
}
