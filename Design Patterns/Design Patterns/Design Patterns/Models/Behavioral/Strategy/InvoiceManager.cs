using Design_Patterns.Models.Behavioral.Strategy.DiscountStrategy;

namespace Design_Patterns.Models.Behavioral.Strategy
{
    public class InvoiceManager
    {
        private readonly ICustomerDiscountStrategy _customerDiscount;
        public InvoiceManager(ICustomerDiscountStrategy customerDiscount)
        {
            _customerDiscount = customerDiscount;
        }

        public Invoice CreateInvoice(Customer user,double unitPrice,double quantity)
        {
            var invoice = new Invoice
            {
                Customer = user,
                Lines = new[]
                {
                  new Invoiceline { UnitPrice = unitPrice, Quantity = quantity },
                },
                DiscountPercentage = _customerDiscount.CalculateDiscount(unitPrice * quantity),
            };
            return invoice;
        }
    }
}
