﻿namespace Bookify.Web.Core.Models
{
	public class UserViewModel
	{
		public string Id { get; set; } = null!;
		public string FullName { get; set; } = null!;
		public string UserName { get; set; } = null!;
		public string Email { get; set; } = null!;
		public bool isDeleted { get; set; }
		public DateTime? CreatedOn { get; set; }
		public DateTime? LastUpdatedOn { get; set; }
	}
}