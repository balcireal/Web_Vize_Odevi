using Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDelivery.Model.Dtos.Customer
{
    public class CustomerPostDto : IDto
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Phone { get; set; }
        public string? City { get; set; }
        public string? PictureBase64 { get; set; }
        public string? PicturePath { get; set; }

    }
}
