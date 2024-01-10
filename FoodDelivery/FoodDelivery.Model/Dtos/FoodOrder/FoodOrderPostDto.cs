using Infrastructure.Model;

namespace FoodDelivery.Model.Dtos.FoodOrder
{
    public class FoodOrderPostDto : IDto
    {
        public int CustomerId { get; set; }
        public int RestaurantId { get; set; }
        public int CustomerAddressId { get; set; }
        public int DeliveryDriverId { get; set; }
        public int OrderStatusId { get; set; }
        // public DateTime? OrderDateTime { get; set; }
        public decimal TotalAmount { get; set; }

        public decimal DeliveryFee { get; set; }
    }
}
