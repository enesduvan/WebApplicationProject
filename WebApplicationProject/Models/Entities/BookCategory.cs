using System.ComponentModel.DataAnnotations;

namespace WebApplicationProject.Models.Entities
{
    public class BookCategory
    {
        [Key] // Primary key
        public int CategoryId { get; set; }
        [Required]  // Category name is required
        public string CategoryName { get; set; }

    }
}
