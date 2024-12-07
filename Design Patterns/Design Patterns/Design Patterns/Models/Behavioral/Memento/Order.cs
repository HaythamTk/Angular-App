namespace Design_Patterns.Models.Behavioral.Memento
{
    //orgenator the obj i save the state of it
    public class Order
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Count { get; set; }

        private  List<OrderLine> _lines  = new();
        public IEnumerable<OrderLine> Lines => _lines.AsReadOnly();

        public void AddProduct(Product product) {
            _lines.Add(new OrderLine {Id = product.Id,Name = product.Name,Price= product.Price });
        }

        public void RemoveProductAt(int index)
        {
            _lines.RemoveAt(index);
        }
        public OrderMemento SaveStateToMemento()
        {
            return new OrderMemento(_lines.ToArray());
        }
        public void RestoreStateForMemento(OrderMemento memento)
        {
            _lines = new List<OrderLine>(memento.GetLines());
        }
    }


}
