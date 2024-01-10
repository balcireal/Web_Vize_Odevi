using AutoMapper;
using FoodDelivery.Model.Dtos.Restaurant;
using FoodDelivery.Model.Entities;

namespace FoodDelivery.Business.Profiles
{
    public class RestaurantProfile : Profile
    {
        public RestaurantProfile()
        {
           
            CreateMap<Restaurant, RestaurantGetDto>()
                .ForMember(dest => dest.FullAddress,
                       opt => opt.MapFrom(src => src.Address.FullAddress));


            CreateMap<RestaurantPostDto, Restaurant>();
            CreateMap<RestaurantPutDto, Restaurant>();

        }
    }
}
