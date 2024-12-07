using Design_Patterns.Models;
using Design_Patterns.Models.Behavioral;
using Design_Patterns.Models.Behavioral.ChainOfResponsibility;
using Design_Patterns.Models.Behavioral.Memento;
using Design_Patterns.Models.Behavioral.State;
using Design_Patterns.Models.Behavioral.Strategy;
using Design_Patterns.Models.Behavioral.Strategy.DiscountStrategy;
using Design_Patterns.Models.Behavioral.Template;
using Design_Patterns.Models.Creational.BuilderPattern;
using Design_Patterns.Models.Creational.FactoryMethod;
using Design_Patterns.Models.Creational.SimpleFactory;
using Design_Patterns.Models.Creational.Singelton;
using Design_Patterns.Models.Structural.Adapter;
using Design_Patterns.Models.Structural.Decorator;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using Employee = Design_Patterns.Models.Behavioral.ChainOfResponsibility.Employee;
using Order = Design_Patterns.Models.Behavioral.State.Order;

namespace Design_Patterns.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DesignPatterns : ControllerBase
    {
        private static CareTaker careTaker = new();
        private static Models.Behavioral.Memento.Order mementoOrder = new();


        [HttpGet("Singelton")]
        public IActionResult Singelton(string baseCurrency, string targetCurrency,double amount)
        {
            var totalAmount= CurrencyConverter.Instance.Convert(baseCurrency, targetCurrency, amount);
            return Ok(totalAmount);
        }


        [HttpGet("Adapter")]
        public IActionResult Adapter(double salary)
        {
            var machine = new MachineOperator();
            machine.BasicSalary = salary;
            SalaryAdapter calculator = new SalaryAdapter();
            var theSalary = calculator.CalcSalary(machine);
            return Ok(theSalary);
        }
        /// <summary>
        /// Strategy is a behavioral design pattern that lets you define a family of algorithms,
        /// put each of them into a separate class, and make their objects interchangeable.
        /// </summary>
        [HttpGet("Strategy")]
        public IActionResult Strategy(double quantity, double unitPrice,int userId)
        {
            var  customers = new List<Customer>{
                new Customer {Id = 1,Name ="Haytham",CustomerStrategy = "New"},
                new Customer {Id = 2,Name ="Husam",CustomerStrategy = "Gold"},
            };
            var user = customers.Find(x => x.Id == userId);
            ICustomerDiscountStrategy customerDiscountStrategy;
            if (user.CustomerStrategy == "Gold")
                customerDiscountStrategy = new GoldCustomer();
            else
                customerDiscountStrategy = new NewCustomer();

            var v = new InvoiceManager(customerDiscountStrategy);
            var invoice = v.CreateInvoice(user, unitPrice, quantity);


            return Ok($"{invoice.Customer.Name} {invoice.NetPrice}");
        }

        [HttpGet("SimpleFactory")]
        public IActionResult SimpleFactory(double quantity, double unitPrice, int userId)
        {
            var customers = new List<Customer>{
                new Customer {Id = 1,Name ="Haytham",CustomerStrategy = "New"},
                new Customer {Id = 2,Name ="Husam",CustomerStrategy = "Gold"},
            };
            var user = customers.Find(x => x.Id == userId);
            //simple factory class
            ICustomerDiscountStrategy customerDiscountStrategy = new CustomerDiscountSimpleFactory().CreateCustomerDiscountStrategy(user.CustomerStrategy);

            var invoice = new Invoice
            {
                Customer = user,
                Lines = new[]
                {
                    new Invoiceline { UnitPrice = unitPrice, Quantity = quantity },
                 },
                DiscountPercentage = customerDiscountStrategy.CalculateDiscount(unitPrice * quantity),
            };

            return Ok($"{invoice.Customer.Name} {invoice.NetPrice}");
        }


         //use when i have operation i know the order for run but not know some steps how works 
        /// <summary>
        /// The Template Method pattern suggests that you break down an algorithm into a series of steps,
        /// turn these steps into methods, and put a series of calls to these methods inside a single template method. 
        [HttpGet("TemplateMethod")]
        public IActionResult TemplateMethod(double invoiceValue,string shoppingType)
        {
            if(shoppingType.ToLower() == "online")
            {
                var invoiceOnline = new ShoppingOnline();
                var theInvoiceValue = invoiceOnline.CheckOut(invoiceValue);
                return Ok(theInvoiceValue);
            }

            var invoiceInsite = new ShoppingInsite();
            var theInvoiceValue2 = invoiceInsite.CheckOut(invoiceValue);
            return Ok(theInvoiceValue2);
        }

        //this more than one implementation here i use interface but you can use abstract

        [HttpGet("FactoryMethod")]
        public IActionResult FactoryMethod(string bankNumber)
        {
            var bankCode = bankNumber.Substring(0,6);
            BankFactory bankFactory = new BankFactory();
            Ibank bank = bankFactory.GetBank(bankCode);
            return Ok(bank.Withdraw());
        }


        [HttpGet("StatePattern")]
        public IActionResult Test()
        {
            var order = new Order
            {
                OrderId = 1,
                Price = 100,
            };
            var beforeChangeStatus = order.CurrentStatus;
            order.Canceld();
            var beforeChangeStatus2 = order.CurrentStatus;
            order.Confirmed();
            
            return Ok(new { beforeChangeStatus, beforeChangeStatus2, order.CurrentStatus});
        }
        /// <summary>
        /// ((complex obj) بتسهل عملية انشاء )
        //purpose :  بتأجل انشاء الأوبجيكت للنهاية حتى لا تتحمل تكلفة انشائه بتقسم عملية انشاء الأوبجيكت
         /// </summary>
             
        [HttpGet("BuilderPattern")]
        public IActionResult BuilderPattern(decimal salary)
        {
            var builder = new SalaryCalculatorBuilder();
            var taxes = builder.WithBouns(20);
            var obj = builder.Build();
            var newSalary = obj.Calculate(salary);
            return Ok(newSalary);
        }
         /// <summary>
        /// Decorator is a structural design pattern that lets you attach new behaviors to objects by placing these objects 
       /// inside special wrapper objects that contain the behaviors.
      /// </summary>
           
        [HttpGet("Decorator")]
        public IActionResult Decorator()
        {
            var theOrder = new Models.Structural.Decorator.Order
            {
                Id = 1,
                Name = "Test",
                Count = 1,
            };
            IorderProcess processor = new OrderProcess();
            processor = new OrderProcessorProfilingDecorator(processor);
            var totalTime = processor.Process(theOrder);

            return Ok(totalTime);
        }

        [HttpPost("Momento")]
        public IActionResult Momento(int id,string name,decimal price,int index)

        {
            var product = new Product { Id = id,Name = name,Price = price };

            mementoOrder.AddProduct(product);
            careTaker.AddMemento(mementoOrder.SaveStateToMemento());
            var memento =   careTaker.GetMemento(index);
            mementoOrder.RestoreStateForMemento(memento);
            return Ok(mementoOrder);
        }
        /// <summary>
        /// Chain of Responsibility is a behavioral design pattern that lets you pass
        /// requests along a chain of handlers.
        /// Upon receiving a request, each handler decides either to
        /// process the request or to pass it to the next handler in the chain.
        /// </summary>
        [HttpPost("ChainOfResponsibility")]
        public IActionResult ChainOfResponsibility()
        {
            var request = new VacationRequest {
                Employee = new Employee
                {
                    Id = 1,
                    Name = "Test",
                    JobTitle = JobTiltle.TechnicalManager,
                    IsTerminated = true,
                },
                StartDate = DateTime.Now.AddDays(10),
                EndDate = DateTime.Now.AddDays(12),
            };
            var teamLeaderHandler = new TeamLeaderApprovalHandler();
            var technicalManagerHandler = new TechnicalManagerApprovalHandler();
            var ctoHandler = new CtoApprovalHandler();
            var ceoHandeler = new CeoApprovalHandler();
            //the chain i can change the order for it
            teamLeaderHandler.SetNextHandler(technicalManagerHandler);
            technicalManagerHandler.SetNextHandler(ctoHandler);
            ctoHandler.SetNextHandler(ceoHandeler);

             teamLeaderHandler.Process(request);
            return Ok(request);
        }

    }
}
