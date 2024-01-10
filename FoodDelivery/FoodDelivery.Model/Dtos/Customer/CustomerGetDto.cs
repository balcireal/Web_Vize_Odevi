using Infrastructure.Model;

namespace FoodDelivery.Model.Dtos.Customer
{
    public class CustomerGetDto : IDto
    {
        
        public string? FirstName{ get; set; }
        public string? LastName { get; set; }

        public string? Phone { get; set; }
        public string? City { get; set; }
        public string CustomerPicture { get; set; }
        public string? PicturePath { get; set; }

    }
}
