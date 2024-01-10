using AutoMapper;
using FoodDelivery.Model.Dtos.CustomerAddress;
using FoodDelivery.Model.Entities;

namespace FoodDelivery.Business.Profiles
{
    public class CustomerAddressProfile : Profile
    {
        public CustomerAddressProfile()
        {

            CreateMap<CustomerAddress, CustomerAddressGetDto>()
                .ForMember(dest => dest.FirstName,
                       opt => opt.MapFrom(src => src.Customer.FirstName))
                .ForMember(dest => dest.FullAddress,
                       opt => opt.MapFrom(src => src.Address.FullAddress));


            CreateMap<CustomerAddressPostDto, CustomerAddress>();
            CreateMap<CustomerAddressPutDto, CustomerAddress>();

        }
    }
}
