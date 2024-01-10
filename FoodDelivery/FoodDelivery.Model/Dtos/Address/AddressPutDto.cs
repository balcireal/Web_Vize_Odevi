using Infrastructure.Model;

namespace FoodDelivery.Model.Dtos.Address
{
    public class AddressPutDto : IDto
    {
        public int AddressId { get; set; }
        public string? UnitNumber { get; set; }
        public string? FullAddress { get; set; }
        public string? City { get; set; }
        public string? Region { get; set; }
        public string? PostalCode { get; set; }

    }
}
