using FoodDelivery.Model.Entities;
using Infrastructure.DataAccess.Interfaces;

namespace FoodDelivery.DataAccess.Interfaces
{
    public interface IOrderStatusRepository : IBaseRepository<OrderStatus>
    {
        Task<List<OrderStatus>> GetByStatusValueAsync(string status, params string[] includeList);
        Task<OrderStatus> GetByIdAsync(int orderStatusId, params string[] includeList);
    }
}
