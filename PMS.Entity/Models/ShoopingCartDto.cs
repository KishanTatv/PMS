namespace PMS.Entity.Models
{
    public class ShoopingCartDto
    {
        public int ProductId { get; set; }
        public int Count { get; set; }
        public string ApplicationUserId { get; set; }
    }

    public class CartProductDto
    {
        public int CartId { get; set; }
        public int ProductId { get; set; }
        public string ProductTitle { get; set; }
        public double Price { get; set; }
        public int Count { get; set; }
        public double TotalPrice { get; set; }
    }

    public class CartDto
    {
        public IEnumerable<CartProductDto> CartProducts { get; set; }
        public double CartTotal { get; set; }
    }
}
