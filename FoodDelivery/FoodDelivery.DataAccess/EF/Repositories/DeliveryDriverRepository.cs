using FoodDelivery.DataAccess.EF.Contexts;
using FoodDelivery.DataAccess.Interfaces;
using FoodDelivery.Model.Entities;
using Infrastructure.DataAccess.Implementations.EF;

namespace FoodDelivery.DataAccess.EF.Repositories
{
    public class DeliveryDriverRepository : BaseRepository<DeliveryDriver, FoodDeliveryDbContext>, IDeliveryDriverRepository
    {
        public async Task<List<DeliveryDriver>> GetByFirstNameAsync(string firstName, params string[] includeList)
        {
            return await GetAllAsync(dver => dver.FirstName.Contains(firstName), includeList);
        }

        public async Task<DeliveryDriver> GetByIdAsync(int deliveryDriverId, params string[] includeList)
        {
            return await GetAsync(dver => dver.DeliveryDriverId == deliveryDriverId, includeList);
        }

        public async Task<List<DeliveryDriver>> GetByPhoneAsync(string phone, params string[] includeList)
        {
            return await GetAllAsync(dver => dver.Phone.Contains(phone), includeList);
        }
    }
}
