using FoodDelivery.Model.Dtos.Product;
using FoodDelivery.Model.Dtos.Restaurant;
using FoodDelivery.Model.Entities;
using Infrastructure.Utilities.ApiResponses;

namespace FoodDelivery.Business.Interfaces
{
    public interface IRestaurantBs
    {
        Task<ApiResponse<List<RestaurantGetDto>>> GetRestaurantsAsync(params string[] includeList);
        Task<ApiResponse<List<RestaurantGetDto>>> GetRestaurantsByRestaurantNameAsync(string name, params string[] includeList);
        Task<ApiResponse<RestaurantGetDto>> GetByIdAsync(int restaurantId, params string[] includeList);
        Task<ApiResponse<Restaurant>> InsertAsync(RestaurantPostDto entity);
        Task<ApiResponse<NoData>> UpdateAsync(RestaurantPutDto entity);
        Task<ApiResponse<NoData>> DeleteAsync(int id);
    }
}
