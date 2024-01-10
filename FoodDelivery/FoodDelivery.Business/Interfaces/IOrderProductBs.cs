using FoodDelivery.Model.Dtos.OrderProduct;
using FoodDelivery.Model.Dtos.Product;
using FoodDelivery.Model.Entities;
using Infrastructure.Utilities.ApiResponses;

namespace FoodDelivery.Business.Interfaces
{
    public interface IOrderProductBs
    {
        Task<ApiResponse<List<OrderProductGetDto>>> GetOrderProductsAsync(params string[] includeList);
        Task<ApiResponse<List<OrderProductGetDto>>> GetOrderProductsByQtyOrderedAsync(decimal min, decimal max, params string[] includeList);
        Task<ApiResponse<OrderProductGetDto>> GetByIdAsync(int orderProductId, params string[] includeList);
        Task<ApiResponse<OrderProduct>> InsertAsync(OrderProductPostDto dto);
        Task<ApiResponse<NoData>> UpdateAsync(OrderProductPutDto entity);
        Task<ApiResponse<NoData>> DeleteAsync(int id);
    }
}
