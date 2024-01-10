using FoodDelivery.Model.Dtos.AdminUser;
using Infrastructure.Utilities.ApiResponses;

namespace FoodDelivery.Business.Interfaces
{
    public interface IAdminUserBs
    {
        Task<ApiResponse<AdminUserGetDto>> LogIn(string userName, string password, params string[] includeList);
    }
}
