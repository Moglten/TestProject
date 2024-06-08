using System.ComponentModel.DataAnnotations;

namespace ClientProductApp.Applicationlayer.Models.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Name must be less than 50 characters")]
        [MinLength(5, ErrorMessage = "Name must be more than 5 characters")]
        public string Name { get; set; }

        [Required]
        [MaxLength(150, ErrorMessage = "Description must be less than 150 characters")]
        [MinLength(10, ErrorMessage = "Description must be more than 10 characters")]
        public string Description { get; set; }

        [Required]
        public bool IsActive { get; set; }
    }
}
