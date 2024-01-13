using Bookify.Web.Core.Models;
using Bookify.Web.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;

namespace Bookify.Web.Controllers
{
	//[Authorize(Roles ="Admin")]
	public class UsersController : Controller
	{
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly RoleManager<IdentityRole> _roleManager;
		private readonly IEmailSender _emailSender;
		private readonly IEmailBodyBuilder _emailBodyBuilder;

        public UsersController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager,IEmailSender emailSender,IEmailBodyBuilder emailBodyBuilder) 
        {
            _roleManager = roleManager;
            _userManager = userManager;
			_emailSender = emailSender;
			_emailBodyBuilder = emailBodyBuilder;


		}


		public IActionResult Index()
		{
			var users = _userManager.Users.Select(x=> new UserViewModel 
			{ FullName = x.FullName,
			  UserName = x.UserName,
			  Email = x.Email,
			  Id = x.Id,
			  CreatedOn = x.CreatedOn,
			  isDeleted = x.IsDeleted,
			  LastUpdatedOn = x.LastUpdatedOn})
		     .ToList();
		     return View(users);
		}

		[HttpGet]
		public async Task<IActionResult> Create()
		{
			var roles = new UserFormViewModel()
			{
				Roles = await _roleManager.Roles.Select(r=> new SelectListItem{
					Text = r.Name,
					Value = r.Name,
				}).ToListAsync(),
				///////
				
			};

			return View(roles);
		}

        [HttpPost]
        public async Task<IActionResult> Create(UserFormViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest();
			var v = User.FindFirst(ClaimTypes.NameIdentifier)!.Value;
            ApplicationUser user = new()
            {
                FullName = model.FullName,
                UserName = model.UserName,
                Email = model.Email,
                CreatedById = User.FindFirst(ClaimTypes.NameIdentifier)!.Value
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRolesAsync(user, model.SelectedRoles);
				var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
				code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
				var callbackUrl = Url.Page(
					"/Account/ConfirmEmail",
					pageHandler: null,
					values: new { area = "Identity", userId = user.Id, code },
					protocol: Request.Scheme);
				var body = _emailBodyBuilder.GetEmailBody(
						"https://res.cloudinary.com/devcreed/image/upload/v1668732314/icon-positive-vote-1_rdexez.svg",
						$"Hey {user.FullName}, thanks for joining us!",
						"please confirm your email",
						$"{HtmlEncoder.Default.Encode(callbackUrl!)}",
						"Active Account!"
					);
				//var body = "please confirm your email"+ $"{HtmlEncoder.Default.Encode(callbackUrl!)} Active Account!";
					

				await _emailSender.SendEmailAsync(user.Email, "Confirm your email", body);

				return RedirectToAction(nameof(Index));
            }
			model.ErroeMessage = string.Join(',', result.Errors.Select(e => e.Description));
			var roles = await _roleManager.Roles.ToListAsync();
			model.Roles = await _roleManager.Roles.Select(r => new SelectListItem
			{
				Text = r.Name,
				Value = r.Name,
			}).ToListAsync();
			
            return View(model);
        }
    }
}
