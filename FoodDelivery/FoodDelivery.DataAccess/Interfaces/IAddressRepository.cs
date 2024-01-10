using FoodDelivery.Model.Entities;
using Infrastructure.DataAccess.Interfaces;

namespace FoodDelivery.DataAccess.Interfaces
{
    public interface IAddressRepository : IBaseRepository<Address>
    {
        Task<List<Address>> GetByCityAsync(string city, params string[] includeList);
        Task<List<Address>> GetByRegionAsync(string region, params string[] includeList);
        Task<Address> GetByIdAsync(int addressId, params string[] includeList);
    }
}
