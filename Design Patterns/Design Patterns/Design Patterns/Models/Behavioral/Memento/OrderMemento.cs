namespace Design_Patterns.Models.Behavioral.Memento
{
    //contain state of obj
    public class OrderMemento
    {
        private readonly IEnumerable<OrderLine> _lines;
        public OrderMemento(IEnumerable<OrderLine> lines)
        {
            _lines = lines;

        }
        public IEnumerable<OrderLine> GetLines()
        {
            return _lines;
        }
    }
}
