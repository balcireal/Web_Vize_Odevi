using FoodDelivery.Model.Dtos.Category;
using FoodDelivery.Model.Entities;
using Infrastructure.Utilities.ApiResponses;

namespace FoodDelivery.Business.Interfaces
{
    public interface ICategoryBs
    {
        Task<ApiResponse<List<CategoryGetDto>>> GetCategoriesAsync(params string[] includeList);
        Task<ApiResponse<List<CategoryGetDto>>> GetCategoriesByCategoryNameAsync(string name, params string[] includeList);
        Task<ApiResponse<List<CategoryGetDto>>> GetCategoriesByDescriptionAsync(string description, params string[] includeList);
        Task<ApiResponse<CategoryGetDto>> GetByIdAsync(int categoryId, params string[] includeList);
        // Task<ApiResponse<Category>> InsertAsync(CategoryPostDto dto);
        Task<ApiResponse<CategoryGetDto>> InsertAsync(CategoryPostDto dto);
        Task<ApiResponse<NoData>> DeleteAsync(int id);
        Task<ApiResponse<NoData>> UpdateAsync(CategoryPutDto entity);
    }
}
