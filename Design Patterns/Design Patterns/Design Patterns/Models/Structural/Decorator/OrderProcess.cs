namespace Design_Patterns.Models.Structural.Decorator
{
    public class OrderProcess : IorderProcess
    {
        public string Process(Order order)
        {
            return "processed";
        }
    }
}
