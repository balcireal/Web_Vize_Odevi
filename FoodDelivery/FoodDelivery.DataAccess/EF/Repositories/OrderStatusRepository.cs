using FoodDelivery.DataAccess.EF.Contexts;
using FoodDelivery.DataAccess.Interfaces;
using FoodDelivery.Model.Entities;
using Infrastructure.DataAccess.Implementations.EF;

namespace FoodDelivery.DataAccess.EF.Repositories
{
    public class OrderStatusRepository : BaseRepository<OrderStatus, FoodDeliveryDbContext>, IOrderStatusRepository
    {
        public async Task<OrderStatus> GetByIdAsync(int orderStatusId, params string[] includeList)
        {
            return await GetAsync(ost => ost.OrderStatusId== orderStatusId, includeList);  
        }

        public async Task<List<OrderStatus>> GetByStatusValueAsync(string status, params string[] includeList)
        {
            return await GetAllAsync(ost => ost.StatusValue.Contains(status), includeList);
        }
    }
}
