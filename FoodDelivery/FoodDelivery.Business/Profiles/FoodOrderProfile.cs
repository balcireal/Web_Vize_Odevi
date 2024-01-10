using AutoMapper;
using FoodDelivery.Model.Dtos.FoodOrder;
using FoodDelivery.Model.Entities;

namespace FoodDelivery.Business.Profiles
{
    public class FoodOrderProfile : Profile
    {
        public FoodOrderProfile()
        {
            CreateMap<FoodOrder, FoodOrderGetDto>();

            CreateMap<FoodOrderPostDto, FoodOrder>();





            CreateMap<FoodOrderPutDto, FoodOrder>();
        }
    }
}
