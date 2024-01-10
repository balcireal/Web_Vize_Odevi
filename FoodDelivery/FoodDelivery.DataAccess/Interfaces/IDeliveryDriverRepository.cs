using FoodDelivery.Model.Entities;
using Infrastructure.DataAccess.Interfaces;

namespace FoodDelivery.DataAccess.Interfaces
{
    public interface IDeliveryDriverRepository : IBaseRepository<DeliveryDriver>
    {
        Task<List<DeliveryDriver>> GetByFirstNameAsync(string firstName, params string[] includeList);
        Task<List<DeliveryDriver>> GetByPhoneAsync(string phone, params string[] includeList);
        Task<DeliveryDriver> GetByIdAsync(int deliveryDriverId, params string[] includeList);
    }
}
