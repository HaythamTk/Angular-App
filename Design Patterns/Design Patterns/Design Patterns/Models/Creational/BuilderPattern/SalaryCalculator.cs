namespace Design_Patterns.Models.Creational.BuilderPattern
{
    public class SalaryCalculator
    {
        public SalaryCalculator(int taxPercentage, decimal bonusPercentage, decimal educationPackage, decimal transportation)
        {
            this.TaxPercentage = taxPercentage;
            this.BonusPercentage = bonusPercentage;
            this.EducationPackage = educationPackage;
            this.Transportation = transportation;
            
        }
        public int TaxPercentage { get;}
        public decimal BonusPercentage { get;}
        public decimal EducationPackage { get;}
        public decimal Transportation { get;}

        public decimal Calculate(decimal salary)
        {
            var newSalary = salary * BonusPercentage + salary + EducationPackage;
            return newSalary;
        }
    }
}
