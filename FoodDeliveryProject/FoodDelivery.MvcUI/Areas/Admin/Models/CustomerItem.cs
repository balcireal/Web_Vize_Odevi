using System.ComponentModel.DataAnnotations.Schema;

namespace FoodDelivery.MvcUI.Areas.Admin.Models
{
    public class CustomerItem
    {
        public int CustomerId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Phone { get; set; }
        public string? City { get; set; }
        public string? CustomerPicture { get; set; }
        public string? PicturePath { get; set; }

    }
}
