using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;

namespace Bookify.Web.Core.ViewModels
{
    public class UserFormViewModel
    {
        public string? Id { get; set; }
        public string FullName { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;

        [DataType(DataType.Password), Display(Name = "Confirm password"),
            Compare("Password")]
        public string ConfirmPassword { get; set; } = null!;

        [Display(Name = "Roles")]
        public IList<string> SelectedRoles { get; set; } = new List<string>();

        public IEnumerable<SelectListItem>? Roles { get; set; }

        public string? ErroeMessage { get; set; }
    }
}
