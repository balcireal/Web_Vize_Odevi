using Infrastructure.Model;

namespace FoodDelivery.Model.Dtos.OrderProduct
{
    public class OrderProductPutDto : IDto
    {
        public int OrderProductId { get; set; }
        public int QtyOrdered { get; set; }
    }
}
