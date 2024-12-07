namespace Design_Patterns.Models.Behavioral.State
{
    public class OrderDraftState : IorderState
    {
        private readonly Order _order;
        public OrderDraftState(Order order)
        {
            _order = order;
            _order.CurrentStatus = "Draft";
        }
        public void Canceld()
        {
            _order.State = new OrderCanceldState(_order);
        }

        public void Confirmed()
        {
            throw new NotImplementedException();
        }

        public void Delivered()
        {
            throw new NotImplementedException();
        }

        public void Returned()
        {
            throw new NotImplementedException();
        }

        public void Shiped()
        {
            throw new NotImplementedException();
        }

        public void UnderProcessing()
        {
            throw new NotImplementedException();
        }
    }
}
