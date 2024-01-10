using Infrastructure.Model;

namespace FoodDelivery.Model.Dtos.Restaurant
{
    public class RestaurantPutDto : IDto
    {
        public int RestaurantId { get; set; }
        public string? RestaurantName { get; set; }
    }
}
