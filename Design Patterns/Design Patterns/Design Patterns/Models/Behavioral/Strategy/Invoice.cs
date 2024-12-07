namespace Design_Patterns.Models.Behavioral.Strategy
{
    public class Invoice
    {
        public Customer Customer { get; set; }

        public IEnumerable<Invoiceline> Lines {  get; set; }

        public double TotalPrice => Lines.Sum(x=>x.UnitPrice * x.Quantity);
        public double DiscountPercentage { get; set; }
        public double NetPrice => TotalPrice - (TotalPrice * DiscountPercentage);

    }
}
