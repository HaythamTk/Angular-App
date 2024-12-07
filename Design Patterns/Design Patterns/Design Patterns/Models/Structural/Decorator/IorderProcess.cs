namespace Design_Patterns.Models.Structural.Decorator
{
    public interface IorderProcess
    {
        public string Process(Order order);
        public string Process(Order order, string name)
        {
            return "";
        }
    }
}
