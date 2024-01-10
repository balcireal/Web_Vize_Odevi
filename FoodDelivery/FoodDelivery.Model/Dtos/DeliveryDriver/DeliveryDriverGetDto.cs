using Infrastructure.Model;

namespace FoodDelivery.Model.Dtos.DeliveryDriver
{
    public class DeliveryDriverGetDto : IDto
    {
        
        
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Phone { get; set; }
        public byte[]? Picture { get; set; }
    }
}
