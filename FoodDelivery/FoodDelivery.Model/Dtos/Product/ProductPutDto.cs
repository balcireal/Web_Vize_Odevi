using Infrastructure.Model;
namespace FoodDelivery.Model.Dtos.Product
{
    public class ProductPutDto : IDto
    {
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public int RestaurantId { get; set; }
        //public int RestaurantId { get; set; }

    }
}   
