using AutoMapper;
using Bookify.Web.Core.Models;
using Bookify.Web.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bookify.Web.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CategoriesController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Index()
        {
            //TODO: use viewModel
            //var categories = _context.Categories
            //    .Select(c=> new CategoryViewModel
            //    {
            //        Id = c.Id,
            //        Name = c.Name,
            //        IsDeleted = c.IsDeleted,
            //        CreatedOn = c.CreatedOn,
            //        LastUpdatedOn = c.LastUpdatedOn

            //    })
            //    .AsNoTracking().Where(x=>!x.IsDeleted).ToList();

            var categories = _context.Categories.AsNoTracking().Where(x => !x.IsDeleted).ToList();

            //use auto Mapper to map data from category to category ViewModel
            var viewModel = _mapper.Map<IEnumerable<CategoryViewModel>>(categories);
            return View(viewModel);
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

            var isExists = _context.Categories.Any(x=>x.Name == model.Name);

            // var category = new Category { Name = model.Name };
            var category =  _mapper.Map<Category>(model);
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

            //category.Name = model.Name;
            //category.LastUpdatedOn = DateTime.Now;
            //mapping by auto mapper
            category = _mapper.Map(model,category);
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

            return Ok();
        }

        public IActionResult AllowItem(CreateCategoryViewModel model)
        {
            var isExists = _context.Categories.Any(x => x.Name == model.Name);
            return Json(!isExists);
        }
    }
}