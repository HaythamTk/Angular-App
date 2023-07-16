using Bookify.Web.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bookify.Web.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CategoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            //TODO: use viewModel
            var categories = _context.Categories.AsNoTracking().Where(x=>!x.IsDeleted).ToList();
            return View(categories);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View("CreateCategory");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateCategoryViewModel model)
        {
            if (!ModelState.IsValid)
                return View("CreateCategory", model);

            var category = new Category { Name = model.Name };
            _context.Add(category);
            _context.SaveChanges();

            TempData["Message"] = "Saved Successfully";
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var category = _context.Categories.Find(id);

            if (category is null)
                return NotFound();

            var viewModel = new EditCategoryViewModel
            {
                Id = id,
                Name = category.Name
            };

            return View("EditCategory", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(EditCategoryViewModel model)
        {
            if (!ModelState.IsValid)
                return View("EditCategory", model);

            var category = _context.Categories.Find(model.Id);

            if (category is null)
                return NotFound();

            category.Name = model.Name;
            category.LastUpdatedOn = DateTime.Now;

            _context.SaveChanges();
            TempData["Message"] = "Saved Successfully";

            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var category = _context.Categories.Find(id);
            if(category is null)
                return NotFound();

            category.IsDeleted = true;
            category.LastUpdatedOn = DateTime.Now;
            _context.SaveChanges();

            return Ok(category.LastUpdatedOn.ToString());
        }
    }
}