namespace Design_Patterns.Models.Behavioral.State
{
    public class OrderCanceldState : IorderState
    {
        private readonly Order _order;
        public OrderCanceldState(Order order)
        {
            _order = order;
            _order.CurrentStatus = "canceld";
        }
        public void Canceld()
        {
            throw new NotImplementedException();
        }

        public void Confirmed()
        {
            _order.State = new OrderConfirmedState(_order); 
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
