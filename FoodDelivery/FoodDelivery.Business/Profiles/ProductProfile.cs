using AutoMapper;
using FoodDelivery.Model.Dtos.Product;
using FoodDelivery.Model.Entities;

namespace FoodDelivery.Business.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {

            CreateMap<Product, ProductGetDto>()
                .ForMember(dest => dest.CategoryName,
                       opt => opt.MapFrom(src => src.Category.CategoryName))
            .ForMember(dest => dest.RestaurantName,
                           opt => opt.MapFrom(src => src.Restaurant.RestaurantName))
            .ForMember(dest => dest.QtyOrdered,
                           opt => opt.MapFrom(src => src.OrderProducts.Sum(orderProduct => orderProduct.QtyOrdered)));



            CreateMap<ProductPostDto, Product>();


            CreateMap<ProductPutDto, Product>();



        }
    }
}
