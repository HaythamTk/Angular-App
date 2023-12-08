using Bookify.Web.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Bookify.Web.Controllers
{
    public class BooksController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _environment;
        private readonly GetDataFromAppSetting _appSetting;
        private readonly int _maxAllowSize = 2097152;
        private readonly List<string> _allowExtension = new(){".jpg",".jpeg",".png",".svg"};
        private readonly IConfiguration _configure;
		public BooksController(ApplicationDbContext context, IWebHostEnvironment environment,IOptions<GetDataFromAppSetting> appSetting,IConfiguration configuration)
		{
			_context = context;
			_environment = environment;
            _appSetting = appSetting.Value;
            _configure = configuration;
		}

		public IActionResult Index()
        {
			return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            //get data from appsetting
			 var theKey1 = _appSetting.Key;
            var theKey2 = _configure["GetDataFromAppSetting:key"];
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
                if (model.Image is not null)
                {
                    if (!_allowExtension.Contains(Path.GetExtension(model.Image.FileName)))
                    {
                        ModelState.AddModelError(nameof(model.Image), "the extension not allow");
                        return View(nameof(Create),model);
                    }
                    if (model.Image.Length > _maxAllowSize)
                    {
						ModelState.AddModelError(nameof(model.Image), "the max size of image must be 2Mb");
						return View(nameof(Create), model);
					}
                    var imageName = model.Image.FileName;
                    var path = Path.Combine($"{_environment.WebRootPath}/images" ,imageName);
                    var stream = System.IO.File.Create(path);
                    model.Image.CopyTo(stream);
				}
				_context.Add(book);
                _context.SaveChanges();
                return Ok();
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
                return Ok();

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
