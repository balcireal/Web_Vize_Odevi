using Infrastructure.Model;

namespace FoodDelivery.Model.Dtos.Product
{
    public class ProductGetDto : IDto
    {
        
        public string? ProductName { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public string  CategoryName { get; set; }
        public string RestaurantName { get; set; }
        public int QtyOrdered { get; set; }
        public byte[]? Picture { get; set; }
    }
}
