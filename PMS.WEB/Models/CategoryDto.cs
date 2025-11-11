using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PMS.Entity.Models
{
    public class CategoryDto
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(20, ErrorMessage="name must be 20 character.")]
        [Remote(action: "IsCategoryNameInUse", controller: "Categories", ErrorMessage = "Category name already exists.")]
        public string Name { get; set; } = null!;
        [DisplayName("Order")]
        [Range(1, 100, ErrorMessage = "orber must be between 1 to 100")]
        public int DisplayOrder { get; set; }
    }
}
