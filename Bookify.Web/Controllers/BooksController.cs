using Bookify.Web.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Bookify.Web.Controllers
{
    public class BooksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BooksController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
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
            return View("CreateBook", viewModel);
        }
        [HttpPost]
        public IActionResult Create(BookFormViewModel model)
        {
            if(ModelState.IsValid)
            {
                var book = new Book
                {
                    Title = model.Title,
                    AuthorId = model.AuthorId,
                    Publisher = model.Publisher,
                    PublishingDate = model.PublishingDate,
                    ImageUrl = model.ImageUrl,
                    Hall = model.Hall,
                    IsAvailableForRental = model.IsAvailableForRental,
                    Description = model.Description,
                };

                foreach(var category in model.SelectedCategories)
                {
                    book.Categories.Add(new BookCategory { CategoryId = category});
                }
                _context.Add(book);
                _context.SaveChanges();
                return View();
            }
            else
            {
                var authors = _context.Authors.Where(a => !a.IsDeleted)
                .Select(a => new SelectListItem { Value = a.Id.ToString(), Text = a.Name })
                .OrderBy(a => a.Text).ToList();

                var categories = _context.Categories.Where(a => !a.IsDeleted)
                    .Select(a => new SelectListItem { Value = a.Id.ToString(), Text = a.Name })
                    .OrderBy(a => a.Text).ToList();

                var viewModel = new BookFormViewModel
                {
                    Authors = authors,
                    Categories = categories,
                };
                return RedirectToAction("Index",viewModel);

            }
            //var authors = _context.Authors.Where(a => !a.IsDeleted)
            //    .Select(a => new SelectListItem { Value = a.Id.ToString(), Text = a.Name })
            //    .OrderBy(a => a.Text).ToList();

            //var categories = _context.Categories.Where(a => !a.IsDeleted)
            //    .Select(a => new SelectListItem { Value = a.Id.ToString(), Text = a.Name })
            //    .OrderBy(a => a.Text).ToList();

            //var viewModel = new BookFormViewModel
            //{
            //    Authors = authors,
            //    Categories = categories,
            //};
            return View();
        }

    }
}
