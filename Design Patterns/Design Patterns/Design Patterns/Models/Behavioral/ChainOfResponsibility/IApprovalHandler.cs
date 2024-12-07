namespace Design_Patterns.Models.Behavioral.ChainOfResponsibility
{
    public interface IApprovalHandler
    {
        void SetNextHandler(IApprovalHandler next);
        void Process(VacationRequest request);
    }
}
