namespace Design_Patterns.Models.Behavioral.ChainOfResponsibility
{
    public class CtoApprovalHandler : ApprovalHandler
    {
        public override void Process(VacationRequest request)
        {
            if (request.Employee.JobTitle == JobTiltle.TechnicalManager)
            {
                throw new Exception("approval by Cto");
            }
            else
            {
                CallNext(request);
            }
        }
    }
}
