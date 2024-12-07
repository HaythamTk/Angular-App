namespace Design_Patterns.Models.Behavioral.Template
{
    public class ShoppingOnline : ShoppingCart
    {
        public override double ApplyDiscount(double invoiceValue)
        {
           if (invoiceValue > 100)
              return  invoiceValue * 0.02;

           return invoiceValue;
        }
    }
}
