using Infrastructure.Model;

namespace FoodDelivery.Model.Dtos.OrderStatus
{
    public class OrderStatusPostDto : IDto
    {
        
        public string? StatusValue { get; set; }
    }
}
