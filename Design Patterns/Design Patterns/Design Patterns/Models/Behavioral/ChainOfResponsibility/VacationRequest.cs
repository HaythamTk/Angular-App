namespace Design_Patterns.Models.Behavioral.ChainOfResponsibility
{
    public class VacationRequest
    {
        public Employee Employee { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public double TotalDays => EndDate.Subtract(StartDate).TotalDays;
        //public double TotalDay()
        //{
        //    return EndDate.Subtract(StartDate).TotalDays;
        //}
    }
}
