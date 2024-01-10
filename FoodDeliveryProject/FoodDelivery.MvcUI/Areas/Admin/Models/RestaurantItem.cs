namespace FoodDelivery.MvcUI.Areas.Admin.Models
{
    public class RestaurantItem
    {
        public int RestaurantId { get; set; }
        public string? RestaurantName { get; set; }
        
        public string? RestaurantPicture { get; set; }
        
        public string? PicturePath { get; set; }

    }
}
