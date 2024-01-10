using Infrastructure.Model;

namespace FoodDelivery.Model.Entities
{
    public class Product : IEntity
    {
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public decimal Price { get; set; }
        public byte[]? Picture { get; set; }
        public int CategoryId { get; set; }
        public int RestaurantId { get; set; }

        public Category? Category { get; set; }
        public Restaurant? Restaurant { get; set; }
        public List<OrderProduct>? OrderProducts { get; set; }


    }
}
