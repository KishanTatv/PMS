namespace PMS.Entity.Models
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public double Price { get; set; }
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
    }

    public class ProductShowDto
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
