using Microsoft.AspNetCore.Identity;

namespace Bookify.Web.Core.Models
{
	public class ApplicationUser : IdentityUser
	{
		public string FullName { get; set; } = null!;
		public string? UpdatedById { get; set; }
		public string? CtreatedById { get; set; }

		public bool IsDeleted { get; set; }
		public DateTime CreatedOn { get; set; } = DateTime.Now;
		public DateTime? LastUpdatedOn { get; set; }
	}
}
