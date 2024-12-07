namespace Design_Patterns.Models.Structural.Adapter
{
    public class SalaryAdapter : SalaryCalculator
    {
        private Employee _emp;

        public double CalcSalary(MachineOperator machine)
        {
            _emp = new Employee();
            _emp.BasicSalary = machine.BasicSalary;
            return Calculator(_emp);
        }
    }
}
