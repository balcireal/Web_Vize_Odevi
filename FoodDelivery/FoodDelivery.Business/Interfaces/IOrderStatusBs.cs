using FoodDelivery.Model.Dtos.OrderStatus;
using FoodDelivery.Model.Dtos.Product;
using FoodDelivery.Model.Entities;
using Infrastructure.Utilities.ApiResponses;

namespace FoodDelivery.Business.Interfaces
{
    public interface IOrderStatusBs
    {
        Task<ApiResponse<List<OrderStatusGetDto>>> GetOrderStatusesAsync(params string[] includeList);
        Task<ApiResponse<List<OrderStatusGetDto>>> GetOrderStatusesByStatusValueAsync(string status, params string[] includeList);
        Task<ApiResponse<OrderStatusGetDto>> GetByIdAsync(int orderStatusId, params string[] includeList);
        Task<ApiResponse<OrderStatus>> InsertAsync(OrderStatusPostDto entity);
        Task<ApiResponse<NoData>> UpdateAsync(OrderStatusPutDto entity);
        Task<ApiResponse<NoData>> DeleteAsync(int id);

    }
}
