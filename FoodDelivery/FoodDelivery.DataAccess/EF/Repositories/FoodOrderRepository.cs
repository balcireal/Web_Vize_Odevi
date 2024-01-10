using FoodDelivery.DataAccess.EF.Contexts;
using FoodDelivery.DataAccess.Interfaces;
using FoodDelivery.Model.Entities;
using Infrastructure.DataAccess.Implementations.EF;

namespace FoodDelivery.DataAccess.EF.Repositories
{
    public class FoodOrderRepository : BaseRepository<FoodOrder, FoodDeliveryDbContext>, IFoodOrderRepository
    {
        public async Task<List<FoodOrder>> GetByDeliveryFeeAsync(decimal min, decimal max, params string[] includeList)
        {
            return await GetAllAsync(ford => ford.DeliveryFee < max && ford.DeliveryFee > min, includeList);
        }

        public async Task<FoodOrder> GetByIdAsync(int foodOrderId, params string[] includeList)
        {
            return await GetAsync(ford => ford.FoodOrderId== foodOrderId, includeList);    
        }

        public async Task<List<FoodOrder>> GetByTotalAmountAsync(decimal min, decimal max, params string[] includeList)
        {
            return  await GetAllAsync(ford => ford.TotalAmount < max && ford.TotalAmount > min, includeList);
        }
    }
}
