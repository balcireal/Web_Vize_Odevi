using Infrastructure.Model;

namespace FoodDelivery.Model.Dtos.Customer
{
    public class CustomerPutDto : IDto
    {
        public int CustomerId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Phone { get; set; }
        public string? City { get; set; }
    }
}
