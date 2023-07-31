using AutoMapper;
using Bookify.Web.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bookify.Web.Controllers
{
    public class AuthorsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public AuthorsController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var authors = _context.Authors.AsNoTracking().Where(x => !x.IsDeleted).ToList();
            var viewModel = _mapper.Map<IEnumerable<AuthorViewModel>>(authors);
            return View(viewModel);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View("CreateAuthor");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(AuthorFormViewModel model)
        {
            if (model.Name =="")
                return View("CreateAuthor", model);

            var isExists = _context.Authors.Any(x => x.Name == model.Name);

            // var category = new Category { Name = model.Name };
            var author = _mapper.Map<Author>(model);
            _context.Add(author);
            _context.SaveChanges();

            TempData["Message"] = "Saved Successfully";
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var author = _context.Authors.Find(id);
            if(author is null)
                return NotFound();
            //  var viewModel = _mapper.Map(author,AuthorFormViewModel);
            var viewModel = _mapper.Map<Author, AuthorFormViewModel>(author);

            return View("EditAuthor", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(AuthorFormViewModel model)
        {
           if(!ModelState.IsValid)
                return View("EditAuthor", model);
            var author = _context.Authors.Find(model.Id);
            if (author is null)
                return NotFound();

             author = _mapper.Map(model, author);
          //  author = _mapper.Map<AuthorFormViewModel,Author>(model);
            author.LastUpdatedOn = DateTime.Now;
            //_context.Update(author);
            _context.SaveChanges();
            TempData["Message"] = "Saved Successfully";

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var author = _context.Authors.Find(id);
            if (author is null)
                return NotFound();

            author.IsDeleted = true;
            author.LastUpdatedOn = DateTime.Now;
            _context.SaveChanges();

            return Ok();
        }
    }
}
