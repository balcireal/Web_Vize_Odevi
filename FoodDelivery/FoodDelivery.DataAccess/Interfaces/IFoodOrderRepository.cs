using FoodDelivery.Model.Entities;
using Infrastructure.DataAccess.Interfaces;

namespace FoodDelivery.DataAccess.Interfaces
{
    public interface IFoodOrderRepository : IBaseRepository<FoodOrder>
    {
        Task<List<FoodOrder>> GetByTotalAmountAsync(decimal min,decimal max, params string[] includeList);
        Task<List<FoodOrder>> GetByDeliveryFeeAsync(decimal min, decimal max, params string[] includeList);
        Task<FoodOrder> GetByIdAsync(int foodOrderId, params string[] includeList);
    }
}
