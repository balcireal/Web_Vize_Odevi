using Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDelivery.Model.Dtos.Restaurant
{
    public class RestaurantPostDto : IDto
    {
        
        public string? RestaurantName { get; set; }
        public string? FullAddress { get; set; }
        public string? PictureBase64 { get; set; }
        public string? PicturePath { get; set; }
    }
}
