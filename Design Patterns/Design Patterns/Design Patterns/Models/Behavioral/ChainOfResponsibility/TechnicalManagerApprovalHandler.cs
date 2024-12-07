namespace Design_Patterns.Models.Behavioral.ChainOfResponsibility
{
    public class TechnicalManagerApprovalHandler : ApprovalHandler
    {
        public override void Process(VacationRequest request)
        {
            if (request.Employee.JobTitle == JobTiltle.TeamLeader || request.Employee.JobTitle == JobTiltle.Developer && request.TotalDays > 3 )
            {
                throw new Exception("approval by Technical Manager");
            }
            else
            {
                CallNext(request);
            }
        }
    }
}
