using Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDelivery.Model.Dtos.Country
{
    public class CountryGetDto : IDto
    {
        
        public string? CountryName { get; set; }
    }
}
