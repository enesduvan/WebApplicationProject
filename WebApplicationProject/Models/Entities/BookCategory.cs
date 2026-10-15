using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApplicationProject.Models.Entities
{
    public class BookCategory
    {
        [Key] // Primary key
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "Kategori adı zorunludur.")]  // Category name is required
        [StringLength(25, ErrorMessage = "Kategori adı en fazla 25 karakter olabilir.")] // Maximum length of 25 characters
        [DisplayName("Kategori Adı")] // Display name for the category
        public string CategoryName { get; set; }

    }
}
