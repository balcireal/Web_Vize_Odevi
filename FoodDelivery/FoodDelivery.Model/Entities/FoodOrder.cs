using Infrastructure.Model;

namespace FoodDelivery.Model.Entities
{
    public class FoodOrder : IEntity
    {
        public int FoodOrderId { get; set; }
        public DateTime? OrderDateTime { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal CustDriverRating { get; set; }
        public decimal CustRestaurantRating { get; set; }
        public decimal DeliveryFee { get; set; }
        public int CustomerId { get; set; }
        public int RestaurantId { get; set; }
        public int CustomerAddressId { get; set; }
        public int DeliveryDriverId { get; set; }
        public int OrderStatusId { get; set; }



        public CustomerAddress? CustomerAddress { get; set; }
        public DeliveryDriver? DeliveryDriver { get; set; }
        public OrderStatus? OrderStatus { get; set; }
        public Customer? Customer { get; set; }
        public Restaurant? Restaurant { get; set; }
        public List<OrderProduct>? OrderProducts { get; set; }

    }
}
