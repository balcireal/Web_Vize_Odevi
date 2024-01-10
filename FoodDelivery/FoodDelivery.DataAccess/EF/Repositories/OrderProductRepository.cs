using FoodDelivery.DataAccess.EF.Contexts;
using FoodDelivery.Model.Entities;
using Infrastructure.DataAccess.Implementations.EF;
using FoodDelivery.DataAccess.Interfaces;

namespace FoodDelivery.DataAccess.EF.Repositories
{
    public class OrderProductRepository : BaseRepository<OrderProduct, FoodDeliveryDbContext>, IOrderProductRepository
    {
        public async Task<OrderProduct> GetByIdAsync(int orderProductId, params string[] includeList)
        {
            return await GetAsync(oprd => oprd.OrderProductId == orderProductId, includeList);
        }

        public async Task<List<OrderProduct>> GetByQtyOrderedAsync(decimal min, decimal max, params string[] includeList)
        {
            return await GetAllAsync(oprd => oprd.QtyOrdered < max && oprd.QtyOrdered > min, includeList);
        }
    }
}
