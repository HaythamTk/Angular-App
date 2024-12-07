namespace Design_Patterns.Models.Creational.Singelton
{
    public class Breif2
    {
        public Breif2()
        {
            
        }

        private static object _lock = new();
        private static Breif2 _inestance;

        private static Breif2 Inestance
        {
            get
            {
               lock (_lock)
                {
                    if (_inestance == null)
                    {
                        _inestance = new Breif2();
                    }
                }
                return _inestance;
            }
        }
    }
}
