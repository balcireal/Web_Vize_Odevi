using FoodDelivery.Model.Dtos.Product;
using FoodDelivery.Model.Entities;
using Infrastructure.Utilities.ApiResponses;

namespace FoodDelivery.Business.Interfaces
{
    public interface IProductBs
    {
        Task<ApiResponse<List<ProductGetDto>>> GetProductsAsync(params string[] includeList);
        Task<ApiResponse<List<ProductGetDto>>> GetProductsByProductNameAsync(string productName, params string[] includeList);
        Task<ApiResponse<List<ProductGetDto>>> GetProductsByPriceRangeAsync(decimal min, decimal max, params string[] includeList);
        Task<ApiResponse<ProductGetDto>> GetByIdAsync(int productId, params string[] includeList);
        Task<ApiResponse<Product>> InsertAsync(ProductPostDto dto);
        Task<ApiResponse<NoData>> UpdateAsync(ProductPutDto entity);
        Task<ApiResponse<NoData>> DeleteAsync(int id);

    }
}
