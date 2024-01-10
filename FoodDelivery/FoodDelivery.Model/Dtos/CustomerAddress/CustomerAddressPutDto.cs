using Infrastructure.Model;

namespace FoodDelivery.Model.Dtos.CustomerAddress
{
    public class CustomerAddressPutDto : IDto
    {
        public int CustomerAddressId { get; set; }
        public int CustomerId { get; set; }
        public int AddressId { get; set; }
    }
}
