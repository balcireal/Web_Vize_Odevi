using FoodDelivery.Model.Entities;
using Infrastructure.DataAccess.Interfaces;

namespace FoodDelivery.DataAccess.Interfaces
{
    public interface IRestaurantRepository : IBaseRepository<Restaurant>
    {
        Task<List<Restaurant>> GetByRestaurantNameAsync(string name, params string[] includeList);
        Task<Restaurant> GetByIdAsync(int restaurantId, params string[] includeList);
    }
}
