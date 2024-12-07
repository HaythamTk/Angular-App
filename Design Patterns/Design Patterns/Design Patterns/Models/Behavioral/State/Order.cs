namespace Design_Patterns.Models.Behavioral.State
{
    public class Order
    {
        public Order()
        {
            State = new OrderDraftState(this);
        }
        public int OrderId { get; set; }
        public double Price { get; set; }
        public IorderState State { get; set; }
        public string CurrentStatus { get; set; }

        public void Confirmed()
        {
            State.Confirmed();
        }
        public void Canceld()
        {
            State.Canceld();
        }
        public void Process()
        {
            State.UnderProcessing();
        }
        public void Ship()
        {
            State.Shiped();
        }
        public void Delivered()
        {
            State.Delivered();
        }
    }
}
