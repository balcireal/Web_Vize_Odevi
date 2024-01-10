using FoodDelivery.Model.Entities;
using Infrastructure.DataAccess.Interfaces;

namespace FoodDelivery.DataAccess.Interfaces
{
    public interface IOrderProductRepository : IBaseRepository<OrderProduct>
    {
        Task<List<OrderProduct>> GetByQtyOrderedAsync(decimal min,decimal max, params string[] includeList);

        Task<OrderProduct> GetByIdAsync(int orderProductId, params string[] includeList);
    }
}
