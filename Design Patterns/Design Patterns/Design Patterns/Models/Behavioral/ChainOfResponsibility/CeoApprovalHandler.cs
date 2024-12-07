namespace Design_Patterns.Models.Behavioral.ChainOfResponsibility
{
    public class CeoApprovalHandler : ApprovalHandler
    {
        public override void Process(VacationRequest request)
        {
            if (request.Employee.JobTitle == JobTiltle.CTO)
            {
                throw new Exception("approval by ceo");
            }
            else
            {
                CallNext(request);
            }
        }
    }
}
