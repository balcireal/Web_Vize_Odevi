using Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDelivery.Model.Dtos.FoodOrder
{
    public class FoodOrderGetDto : IDto
    {

        
        public DateTime? OrderDateTime { get; set; }
        public decimal TotalAmount { get; set; }
        
        public decimal DeliveryFee { get; set; }
    }
}
