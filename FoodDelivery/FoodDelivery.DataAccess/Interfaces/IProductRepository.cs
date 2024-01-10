using FoodDelivery.Model.Entities;
using Infrastructure.DataAccess.Interfaces;

namespace FoodDelivery.DataAccess.Interfaces
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        Task<List<Product>> GetByProductNameAsync(string productName, params string[] includeList);
        Task<List<Product>> GetByPriceRangeAsync(decimal min, decimal max, params string[] includeList);
        Task<Product> GetByIdAsync(int productId, params string[] includeList);
    }
}
