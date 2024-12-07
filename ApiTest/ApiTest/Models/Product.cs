using System.ComponentModel.DataAnnotations;

namespace ApiTest.Models
{
    public class Product
    {
        public string Name { get; set; }
        public string Category { get; set; }
        //public DateTime CreatedDate { get; set; } = DateTime.Now;
        public double Price { get; set; }

        [EmailAddress]
        public string Email { get; set; }
    }
}
