using FoodDelivery.Model.Entities;
using Infrastructure.DataAccess.Interfaces;

namespace FoodDelivery.DataAccess.Interfaces
{
    public interface ICustomerAddressRepository : IBaseRepository<CustomerAddress>
    {
        Task<CustomerAddress> GetByIdAsync(int customerAddressId, params string[] includeList);
    }
}
