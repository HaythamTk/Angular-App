
namespace Design_Patterns.Models.Behavioral.Template
{
    public abstract class ShoppingCart
    {

        //this is the template method contain the operation in order and some process not know who work
        public double CheckOut(double invoiceValue)
        {
            var applyTaxes =  ApplyTaxes(invoiceValue);
            var applyDiscount = ApplyDiscount(invoiceValue);
             return invoiceValue - (applyTaxes + applyDiscount);
        }

        private double ApplyTaxes(double invoiceValue)
        {
            invoiceValue = invoiceValue * 0.02;
             return invoiceValue;
        }
        //the trick i dont know how its run here but in every class online and site i know the operation
        public abstract double ApplyDiscount(double invoiceValue);
        
    }
}
