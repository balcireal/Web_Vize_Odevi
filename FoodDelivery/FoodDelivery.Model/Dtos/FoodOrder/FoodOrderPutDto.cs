using Infrastructure.Model;

namespace FoodDelivery.Model.Dtos.FoodOrder
{
    public class FoodOrderPutDto : IDto
    {
        public int FoodOrderId { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal DeliveryFee { get; set; }
    }
}
