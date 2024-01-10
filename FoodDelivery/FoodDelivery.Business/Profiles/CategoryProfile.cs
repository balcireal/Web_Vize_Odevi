

using AutoMapper;
using FoodDelivery.Model.Dtos.Category;
using FoodDelivery.Model.Entities;

namespace FoodDelivery.Business.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {

            CreateMap<Category, CategoryGetDto>();

            CreateMap<CategoryPostDto, Category>()
         .ForMember(dest => dest.Picture,
                    opt => opt.MapFrom(src =>
                        Convert.FromBase64String(src.PictureBase64)
                      ));
            CreateMap<CategoryPutDto, Category>();





        }
    }
}
