using AutoMapper;
using FoodDelivery.Model.Dtos.Country;
using FoodDelivery.Model.Entities;

namespace FoodDelivery.Business.Profiles
{
    public class CountryProfile : Profile
    {
        public CountryProfile()
        {

            CreateMap<Country, CountryGetDto>();
            CreateMap<CountryPostDto, Country>();
            CreateMap<CountryPutDto, Country>();

        }
    }
}
