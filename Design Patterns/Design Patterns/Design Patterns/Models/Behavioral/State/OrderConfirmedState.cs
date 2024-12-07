namespace Design_Patterns.Models.Behavioral.State
{
    public class OrderConfirmedState : IorderState
    {
        private readonly Order _order;
        public OrderConfirmedState(Order order)
        {
            _order = order;
            _order.CurrentStatus = "Confirmed";
        }
        public void Canceld()
        {
            throw new NotImplementedException();
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
