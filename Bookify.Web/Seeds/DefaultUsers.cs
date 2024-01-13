using Bookify.Web.Core.Models;
using Microsoft.AspNetCore.Identity;

namespace Bookify.Web.Seeds
{
	public static class DefaultUsers
	{
		public static async Task SeedUsers(UserManager<ApplicationUser> userManager)
		{
			if(!userManager.Users.Any())
			{
				var admin = new ApplicationUser()
				{
					UserName = "admin@gmail.com",
					Email = "admin@gmail.com",
					FullName = "admin",
					EmailConfirmed = true,
				};
					await userManager.CreateAsync(admin,"@Admin12345678");
					await userManager.AddToRoleAsync(admin, "Admin");
			}
		}
	}
}
