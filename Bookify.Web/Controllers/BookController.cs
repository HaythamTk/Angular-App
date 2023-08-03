using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Bookify.Web.Controllers
{
    public class BookController : Controller
    {
        private readonly ApplicationDbContext _context;
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            var authors = _context.Authors.Where(a=> !a.IsDeleted)
                .Select(a=> new SelectListItem { Value = a.Id.ToString(),Text = a.Name})
                .OrderBy(a=>a.Text).ToList();

            var categories = _context.Categories.Where(a => !a.IsDeleted)
                .Select(a => new SelectListItem { Value = a.Id.ToString(), Text = a.Name })
                .OrderBy(a => a.Text).ToList();

            var viewModel = new BookFormViewModel
            {
                Authors = authors,
                Categories = categories,
            };
            return View();
        }
    }
}
