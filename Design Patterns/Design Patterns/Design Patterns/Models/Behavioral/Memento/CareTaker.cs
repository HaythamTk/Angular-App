namespace Design_Patterns.Models.Behavioral.Memento
{
    //data store of memento
    public class CareTaker
    {
        private List<OrderMemento> _mementos = new();

        public int AddMemento(OrderMemento memento)
        {
            _mementos.Add(memento);
            return _mementos.Count - 1;
        }
        public OrderMemento GetMemento(int id)
        {
            return _mementos[id];
        }
    }
}
