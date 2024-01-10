using Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDelivery.Model.Dtos.OrderProduct
{
    public class OrderProductPostDto : IDto
    {
        
        public int QtyOrdered { get; set; }
        public string? ProductName { get; set; }
        public decimal TotalAmount { get; set; }
        public int CategoryId { get; set; }
    }
}
