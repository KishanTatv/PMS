using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace PMS.Entity.Models
{
    public class ProductDto
    {
        public int Id { get; set; }
        [MaxLength(20, ErrorMessage = "title must be 20 character.")]
        [Remote(action: "IsExistingPrpoductName", controller: "Product", ErrorMessage = "Title must be unique.", AdditionalFields = "Id")]
        public string Title { get; set; }
        public string ISBN { get; set; }
        [Range(1, 10000, ErrorMessage = "price must be between 1 to 10000")]
        public double Price { get; set; }
        [MaxLength(20, ErrorMessage = "author name must be 20 character.")]
        public string Author { get; set; }
        public int CategoryId { get; set; }
        public int CoverTypeId { get; set; }

    }

    public class ProductDetailDto : ProductDto
    {
        public string Description { get; set; }
        public double ListPrice { get; set; }
        public double Price50 { get; set; }
        public double Price100 { get; set; }
        public string? ImageUrl { get; set; }
        public IFormFile? Image { get; set; }
    }


    public struct ProductShowDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public double Price { get; set; }
        public string Author { get; set; }
        public string CategoryName { get; set; }
        public string CoverTypeName { get; set; }

    }
}
