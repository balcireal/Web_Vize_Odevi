using Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDelivery.Model.Entities
{
    public class DeliveryDriver : IEntity
    {
        public int DeliveryDriverId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Phone { get; set; }
        public byte[]? Picture { get; set; }

        //[NotMapped]
        //public string? FullName
        //{
        //    get
        //    {
        //        return $"{FirstName} {LastName}";
        //    }
        //}

        public List<FoodOrder>? FoodOrders { get; set; }
    }
}
