using Infrastructure.Model;

namespace FoodDelivery.Model.Entities
{
    public class CustomerAddress : IEntity
    {
        public int CustomerAddressId { get; set; }

        public Customer? Customer { get; set; }
        public Address? Address { get; set; }
        public List<FoodOrder>? FoodOrders { get; set; }
    }
}
