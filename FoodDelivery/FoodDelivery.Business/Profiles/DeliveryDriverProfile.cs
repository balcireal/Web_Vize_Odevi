using AutoMapper;
using FoodDelivery.Model.Dtos.DeliveryDriver;
using FoodDelivery.Model.Entities;

namespace FoodDelivery.Business.Profiles
{
    public class DeliveryDriverProfile : Profile
    {
        public DeliveryDriverProfile()
        {
            CreateMap<DeliveryDriver, DeliveryDriverGetDto>();
            CreateMap<DeliveryDriverPostDto, DeliveryDriver>();
            CreateMap<DeliveryDriverPutDto, DeliveryDriver>();

        }
    }
}
