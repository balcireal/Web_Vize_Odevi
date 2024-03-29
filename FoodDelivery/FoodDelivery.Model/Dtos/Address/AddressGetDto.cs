﻿using Infrastructure.Model;

namespace FoodDelivery.Model.Dtos.Address
{
    public class AddressGetDto : IDto
    {
        
        public string? FullAddress { get; set; }
        public string? City { get; set; }
        public string? Region { get; set; }
        public string? PostalCode { get; set; }
    }
}
