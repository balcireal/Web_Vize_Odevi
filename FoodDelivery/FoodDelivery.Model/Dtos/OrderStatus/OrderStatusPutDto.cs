using Infrastructure.Model;

namespace FoodDelivery.Model.Dtos.OrderStatus
{
    public class OrderStatusPutDto : IDto
    {
        public int OrderStatusId { get; set; }
        public string? StatusValue { get; set; }
    }
}
