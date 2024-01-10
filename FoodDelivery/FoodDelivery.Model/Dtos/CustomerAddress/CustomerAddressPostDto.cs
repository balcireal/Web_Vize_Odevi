using Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDelivery.Model.Dtos.CustomerAddress
{
    public class CustomerAddressPostDto : IDto
    {
        
        public string? FirstName { get; set; }
        public string? FullAddress { get; set; }
       
    }
}
