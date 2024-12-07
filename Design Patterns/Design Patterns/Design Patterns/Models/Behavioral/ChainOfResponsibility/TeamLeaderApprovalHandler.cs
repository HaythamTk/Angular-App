namespace Design_Patterns.Models.Behavioral.ChainOfResponsibility
{
    public class TeamLeaderApprovalHandler : ApprovalHandler
    {
        public override void Process(VacationRequest request)
        {
           if(request.Employee.JobTitle == JobTiltle.Developer && request.TotalDays <= 3)
            {
                throw new Exception("approval by leader");
            }
            else
            {
                CallNext(request);
            }
        }
    }
}
