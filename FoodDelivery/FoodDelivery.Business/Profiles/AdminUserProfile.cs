using AutoMapper;
using FoodDelivery.Model.Dtos.AdminUser;
using FoodDelivery.Model.Entities;

namespace FoodDelivery.Business.Profiles
{
    public class AdminUserProfile : Profile
    {
        public AdminUserProfile()
        {
            CreateMap<AdminUser, AdminUserGetDto>();
        }
    }
}
