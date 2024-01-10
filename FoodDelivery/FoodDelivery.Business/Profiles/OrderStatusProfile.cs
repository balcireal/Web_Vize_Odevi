using AutoMapper;
using FoodDelivery.Model.Dtos.Address;
using FoodDelivery.Model.Dtos.Category;
using FoodDelivery.Model.Dtos.Country;
using FoodDelivery.Model.Dtos.Customer;
using FoodDelivery.Model.Dtos.CustomerAddress;
using FoodDelivery.Model.Dtos.DeliveryDriver;
using FoodDelivery.Model.Dtos.FoodOrder;
using FoodDelivery.Model.Dtos.OrderProduct;
using FoodDelivery.Model.Dtos.OrderStatus;
using FoodDelivery.Model.Dtos.Product;
using FoodDelivery.Model.Dtos.Restaurant;
using FoodDelivery.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDelivery.Business.Profiles
{
    public class OrderStatusProfile : Profile
    {
        public OrderStatusProfile()
        {
          
            CreateMap<OrderStatus, OrderStatusGetDto>();
            CreateMap<OrderStatusPostDto, OrderStatus>();
            CreateMap<OrderStatusPutDto, OrderStatus>();
            
        }
    }
}
