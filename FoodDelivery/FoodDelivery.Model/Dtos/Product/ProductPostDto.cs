using Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDelivery.Model.Dtos.Product
{
    public class ProductPostDto : IDto
    {
      
        public string? ProductName { get; set; }
        public decimal Price { get; set; }

        // public string? CategoryId { get; set; }
        public int CategoryId { get; set; }
        public int RestaurantId { get; set; }


        public string? RestaurantName { get; set; }
        public int QtyOrdered { get; set; }
    }
}
