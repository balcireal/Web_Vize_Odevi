using Infrastructure.Model;

namespace FoodDelivery.Model.Entities
{
    public class Address : IEntity
    {
        public int AddressId { get; set; }
        public string? UnitNumber { get; set; }
        public string? FullAddress { get; set; }
        public string? City { get; set; }
        public string? Region { get; set; }
        public string? PostalCode { get; set; }

        public List<Restaurant>? Restaurants { get; set; }
        public Country? Country { get; set; }
        public List<CustomerAddress>? CustomerAddresses { get; set; }

    }
}
