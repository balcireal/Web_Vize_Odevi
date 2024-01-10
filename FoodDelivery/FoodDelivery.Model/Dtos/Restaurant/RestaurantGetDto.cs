using Infrastructure.Model;

namespace FoodDelivery.Model.Dtos.Restaurant
{
    public class RestaurantGetDto : IDto
    {
       
        public string? RestaurantName { get; set; }
        public string? FullAddress { get; set; }
        public string RestaurantPicture { get; set; }
        public string? PicturePath { get; set; }
    }
}
