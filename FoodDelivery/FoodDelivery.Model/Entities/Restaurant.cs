using Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDelivery.Model.Entities
{
    public class Restaurant : IEntity
    {
        public int RestaurantId { get; set; }
        public string? RestaurantName { get;set; }
        public byte[]? Picture { get; set; }
        public string? PicturePath { get; set; }

        public List<Product>? Products { get; set; }
        public Address? Address { get; set; }
        public List<FoodOrder>? FoodOrders { get; set; }
    }
}
