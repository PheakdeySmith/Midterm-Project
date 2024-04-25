using System.ComponentModel.DataAnnotations;

namespace Midterm_Project.Models
{
    public class Supplier
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string ContactPerson { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
