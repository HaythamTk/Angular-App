namespace Bookify.Web.Core.Models
{
    public class BaseModel
    {
        public bool IsDeleted { get; set; }
        public string? CtreatedById  { get; set; }
		public ApplicationUser? CtreatedBy { get; set; }
		public DateTime CreatedOn { get; set; } = DateTime.Now;
		public string? UpdatedById { get; set; }
		public ApplicationUser? UpdatedBy { get; set; }
		public DateTime? LastUpdatedOn { get; set; }

		
	}
}
