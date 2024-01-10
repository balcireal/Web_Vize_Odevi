using FoodDelivery.DataAccess.EF.Contexts;
using FoodDelivery.DataAccess.Interfaces;
using FoodDelivery.Model.Entities;
using Infrastructure.DataAccess.Implementations.EF;

namespace FoodDelivery.DataAccess.EF.Repositories
{
    public class RestaurantRepository : BaseRepository<Restaurant, FoodDeliveryDbContext>, IRestaurantRepository
    {
        public async Task<Restaurant> GetByIdAsync(int restaurantId, params string[] includeList)
        {
            return await GetAsync(res => res.RestaurantId== restaurantId, includeList);    
        }

        public async Task<List<Restaurant>> GetByRestaurantNameAsync(string name, params string[] includeList)
        {
            return await GetAllAsync(res => res.RestaurantName.Contains(name),includeList);
        }
    }
}
