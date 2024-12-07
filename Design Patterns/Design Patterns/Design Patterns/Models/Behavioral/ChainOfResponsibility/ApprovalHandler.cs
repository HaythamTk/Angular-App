namespace Design_Patterns.Models.Behavioral.ChainOfResponsibility
{
    public abstract class ApprovalHandler : IApprovalHandler
    {
        private  IApprovalHandler _next;
        public abstract void Process(VacationRequest request);

        public void SetNextHandler(IApprovalHandler next)
        {
            _next = next;
        }
        public void CallNext(VacationRequest request)
        {
           if(_next != null)
               _next.Process(request);
        }
    }
}
