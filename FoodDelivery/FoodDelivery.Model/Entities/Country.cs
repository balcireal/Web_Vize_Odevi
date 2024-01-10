using Infrastructure.Model;

namespace FoodDelivery.Model.Entities
{
    public class Country : IEntity
    {
        public int CountryId { get; set; }
        public string? CountryName { get; set; }

        public List<Address>? Addresses { get; set; }
    }
}
