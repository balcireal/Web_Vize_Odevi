using Infrastructure.Model;

namespace FoodDelivery.Model.Dtos.OrderStatus
{
    public class OrderStatusGetDto : IDto
    {
        
        public string? StatusValue { get; set; }
        
    }
}
