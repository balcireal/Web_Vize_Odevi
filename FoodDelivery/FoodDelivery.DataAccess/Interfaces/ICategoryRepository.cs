using FoodDelivery.Model.Entities;
using Infrastructure.DataAccess.Interfaces;

namespace FoodDelivery.DataAccess.Interfaces
{
    public interface ICategoryRepository : IBaseRepository<Category>
    {
        Task<List<Category>> GetByCategoryNameAsync(string name, params string[] includeList);
        Task<List<Category>> GetByDescriptionAsync(string description, params string[] includeList);
        Task<Category> GetByIdAsync(int categoryId, params string[] includeList);
    }
}
