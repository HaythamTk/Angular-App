namespace Design_Patterns.Models.Behavioral.ChainOfResponsibility
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public JobTiltle JobTitle { get; set; }
        public bool IsTerminated { get; set; }
    }
}
