using Bookify.Web.Core.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Bookify.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEmailSender _emailSender;

	

		public HomeController(ILogger<HomeController> logger, IEmailSender emailSender)
        {
            _logger = logger;
			_emailSender = emailSender;

		}

		public async Task<IActionResult> Index()
        {
            await _emailSender.SendEmailAsync("haythamtarakhan383@gmail.com","test email","this is test email");
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}