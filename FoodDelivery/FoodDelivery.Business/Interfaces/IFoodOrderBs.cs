using FoodDelivery.Model.Dtos.FoodOrder;
using FoodDelivery.Model.Dtos.Product;
using FoodDelivery.Model.Entities;
using Infrastructure.Utilities.ApiResponses;

namespace FoodDelivery.Business.Interfaces
{
    public interface IFoodOrderBs
    {
        Task<ApiResponse<List<FoodOrderGetDto>>> GetFoodOrdersAsync(params string[] includeList);
        Task<ApiResponse<List<FoodOrderGetDto>>> GetFoodOrdersByTotalAmountAsync(decimal min, decimal max, params string[] includeList);
        Task<ApiResponse<List<FoodOrderGetDto>>> GetFoodOrdersByDeliveryFeeAsync(decimal min, decimal max, params string[] includeList);
        Task<ApiResponse<FoodOrderGetDto>> GetByIdAsync(int foodOrderId, params string[] includeList);
        Task<ApiResponse<FoodOrder>> InsertAsync(FoodOrderPostDto dto);
        Task<ApiResponse<NoData>> DeleteAsync(int id);
        Task<ApiResponse<NoData>> UpdateAsync(FoodOrderPutDto entity);
    }
}
