using FoodDelivery.DataAccess.EF.Contexts;
using FoodDelivery.DataAccess.Interfaces;
using FoodDelivery.Model.Entities;
using Infrastructure.DataAccess.Implementations.EF;

namespace FoodDelivery.DataAccess.EF.Repositories
{
    public class CategoryRepository : BaseRepository<Category, FoodDeliveryDbContext>, ICategoryRepository
    {
        public async Task<List<Category>> GetByCategoryNameAsync(string name, params string[] includeList)
        {
            return await GetAllAsync(ctg => ctg.CategoryName.Contains(name), includeList);
        }

        public async Task<List<Category>> GetByDescriptionAsync(string description, params string[] includeList)
        {
            return await GetAllAsync(ctg => ctg.Description.Contains(description), includeList);
        }

    public async Task<Category> GetByIdAsync(int categoryId, params string[] includeList)
        {
            return await GetAsync(ctg => ctg.CategoryId == categoryId, includeList);
        }
    }
}
