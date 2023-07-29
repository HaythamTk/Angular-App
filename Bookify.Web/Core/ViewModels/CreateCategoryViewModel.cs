using Microsoft.AspNetCore.Mvc;

namespace Bookify.Web.Core.ViewModels
{
    public class CreateCategoryViewModel
    {
        [MaxLength(100, ErrorMessage = "Max length cannot be more than 5 chr.")]

        [Remote("AllowItem", "Categories", ErrorMessage ="Category with the same name is already existst!")]
        public string Name { get; set; } = null!;
    }
}
