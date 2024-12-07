using System.Diagnostics;
using System.Xml.Linq;

namespace Design_Patterns.Models.Structural.Decorator
{
    public class OrderProcessorProfilingDecorator : IorderProcess
    {
        private readonly IorderProcess _orderProcess;
        public OrderProcessorProfilingDecorator(IorderProcess orderProcess)
        {
            _orderProcess = orderProcess;
        }
        public string Process(Order order)
        {
         
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            _orderProcess.Process(order);
            stopWatch.Stop();
            var totalSeconds = stopWatch.Elapsed.TotalSeconds.ToString();
            return totalSeconds;
        }
    }
}
