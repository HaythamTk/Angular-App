namespace Design_Patterns.Models.Creational.BuilderPattern
{
    public class SalaryCalculatorBuilder
    {
        private int _taxPercentage = 0;
        private decimal _bonusPercentage = 0;
        private decimal _educationPackage = 0;
        private decimal _transportation = 0;

        public SalaryCalculatorBuilder WithTaxes(int taxPercentage ) { 
            _taxPercentage = taxPercentage;
            return this;
        }
        public SalaryCalculatorBuilder WithBouns(int bonusPercentage) {
            _bonusPercentage = bonusPercentage;
            return this;
        }
        public SalaryCalculatorBuilder WithEducation(int educationPackage)
        {
            _educationPackage = educationPackage;
            return this;
        }
        public SalaryCalculatorBuilder WithTransportation(int transportation)
        {
            _transportation = transportation;
            return this;
        }
        //the builder operation
        public SalaryCalculator Build()
        {
          return new SalaryCalculator(_taxPercentage, _bonusPercentage, _educationPackage, _transportation);
        }


    }
}
