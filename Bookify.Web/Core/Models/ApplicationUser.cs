using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Bookify.Web.Core.Models
{
	[Index(nameof(Email),IsUnique = true)]
	[Index(nameof(UserName),IsUnique = true)]
	public class ApplicationUser : IdentityUser
	{
		public string FullName { get; set; } = null!;
		public string? UpdatedById { get; set; }
		public string? CreatedById { get; set; }
		public bool IsDeleted { get; set; }
		public DateTime CreatedOn { get; set; } = DateTime.Now;
		public DateTime? LastUpdatedOn { get; set; }
    }
}
