using Infrastructure.Model;

namespace FoodDelivery.Model.Entities
{
    public class OrderProduct : IEntity
    {
        public int OrderProductId { get; set; }
        public int QtyOrdered { get; set; }

        public FoodOrder? FoodOrder { get; set; }
        public Product? Product { get; set; }

    }
}
