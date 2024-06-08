using ClientProductApp.ApplicationLayer.CustomAttribute;
using ClientProductApp.ApplicationLayer.CustomAttribute.DataValidation;
using ClientProductApp.DomainLayer.Entities;
using System.ComponentModel.DataAnnotations;

namespace ClientProductApp.Applicationlayer.Models.ViewModels
{
    public class ClientViewModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50,ErrorMessage ="Max length of the name is 50 character")]
        public string Name { get; set; }

        [Required]
        [RegularExpression(@"^\d{9}$", ErrorMessage = "The field must be exactly 9 digits.")]
        [CodeDuplicationCheck]
        public string Code { get; set; }
        
        public int Class { get; set; }
        public int State { get; set; }

        public string? CName{ get; set; }
        public string? SName{ get; set; }

        public List<Product>? AttachedProducts { get; set; } = new List<Product>();
    }
}
