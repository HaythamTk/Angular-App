namespace Bookify.Web.Core.ViewModels
{
    public class AuthorFormViewModel
    {
        public string Key { get; set; }

        [MaxLength(100, ErrorMessage = "Max length cannot be more than 5 chr.")]
        public string Name { get; set; } = null!;
    }
}
