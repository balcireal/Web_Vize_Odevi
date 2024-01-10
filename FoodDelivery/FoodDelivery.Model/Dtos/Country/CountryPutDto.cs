using Infrastructure.Model;

namespace FoodDelivery.Model.Dtos.Country
{
    public class CountryPutDto : IDto
    {
        public int CountryId { get; set; }
        public string? CountryName { get; set; }
    }
}
