using FoodDelivery.DataAccess.EF.Contexts;
using FoodDelivery.DataAccess.Interfaces;
using FoodDelivery.Model.Entities;
using Infrastructure.DataAccess.Implementations.EF;

namespace FoodDelivery.DataAccess.EF.Repositories
{
    public class AddressRepository : BaseRepository<Address, FoodDeliveryDbContext>, IAddressRepository
    {
        public async Task<List<Address>> GetByCityAsync(string city, params string[] includeList)
        {
            return await GetAllAsync(add => add.City.Contains(city), includeList);
        }

        public async Task<Address> GetByIdAsync(int addressId, params string[] includeList)
        {
            return await GetAsync(add => add.AddressId == addressId, includeList);
        }

        public async Task<List<Address>> GetByRegionAsync(string region, params string[] includeList)
        {
            return await GetAllAsync(add => add.Region.Contains(region), includeList);
        }
    }
}
