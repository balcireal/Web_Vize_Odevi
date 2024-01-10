using AutoMapper;
using FoodDelivery.Model.Dtos.Customer;
using FoodDelivery.Model.Entities;

namespace FoodDelivery.Business.Profiles
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {

            CreateMap<Customer, CustomerGetDto>();

            CreateMap<CustomerPostDto, Customer>()
                .ForMember(dest => dest.Picture,
                    opt => opt.MapFrom(src =>
                        Convert.FromBase64String(src.PictureBase64)
                      ));

            CreateMap<CustomerPutDto, Customer>();

            
        }
    }
}
