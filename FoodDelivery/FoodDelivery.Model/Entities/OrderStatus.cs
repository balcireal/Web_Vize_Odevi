using Infrastructure.Model;

namespace FoodDelivery.Model.Entities
{
    public class OrderStatus : IEntity
    {
        public int OrderStatusId { get; set; }
        public string? StatusValue { get; set; }

        public List<FoodOrder>? FoodOrders { get; set; }
    }
}
