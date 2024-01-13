namespace Bookify.Web.Core.ViewModels
{
    public class AuthorViewModel
    {
        public int Id { get; set; }
		public string Key { get; set; } = null!;

		[MaxLength(100, ErrorMessage = "Max length cannot be more than 5 chr.")]
        public string Name { get; set; } = null!;

        public bool IsDeleted { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? LastUpdatedOn { get; set; }
    }
}
