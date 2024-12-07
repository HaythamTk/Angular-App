namespace Design_Patterns.Models.Creational.Singelton
{
    public class BriefExample
    {
        private BriefExample()
        {

        }
        private static object _lock = new();
        private static BriefExample _instance;
        public static BriefExample Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                        _instance = new();
                }
                return _instance;
            }
        }
    }
}
