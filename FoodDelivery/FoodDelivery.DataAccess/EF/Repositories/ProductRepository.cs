using FoodDelivery.DataAccess.EF.Contexts;
using FoodDelivery.DataAccess.Interfaces;
using FoodDelivery.Model.Entities;
using Infrastructure.DataAccess.Implementations.EF;

namespace FoodDelivery.DataAccess.EF.Repositories
{
    public class ProductRepository : BaseRepository<Product, FoodDeliveryDbContext>, IProductRepository
    {
        public async Task<Product> GetByIdAsync(int productId, params string[] includeList)
        {
            return await GetAsync(prd => prd.ProductId == productId, includeList);
        }

        public async Task<List<Product>> GetByPriceRangeAsync(decimal min, decimal max, params string[] includeList)
        {
            return await GetAllAsync(prd => prd.Price < max && prd.Price > min, includeList);
        }

        public async Task<List<Product>> GetByProductNameAsync(string productName, params string[] includeList)
        {
            return await GetAllAsync(prd => prd.ProductName.Contains(productName),includeList);
        }
    }
}
