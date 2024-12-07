namespace Design_Patterns.Models.Structural.Adapter
{
    public class SalaryCalculator
    {
        public double Calculator(Employee emp)
        {
            return emp.BasicSalary * 1.5;
        }
    }
}
