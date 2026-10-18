using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationProject.Models.Entities
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string BookName { get; set; }
        public string Description { get; set; }

        [Required]
        public string Ahuthor { get; set; }

        [Required]
        [Range(0, 100000)]
        public double Price { get; set; }

        public string ImageUrl { get; set; }

        /*

        [ValidateNever]
        public int KitapTuruId { get; set; }
        [ForeignKey("KitapTuruId")]

        [ValidateNever]
        public KitapTuru KitapTuru { get; set; }

        [ValidateNever]
        public string ResimUrl { get; set; }
        */
    }
}
