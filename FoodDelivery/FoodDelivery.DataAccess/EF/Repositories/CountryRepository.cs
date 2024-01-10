using FoodDelivery.DataAccess.EF.Contexts;
using FoodDelivery.DataAccess.Interfaces;
using FoodDelivery.Model.Entities;
using Infrastructure.DataAccess.Implementations.EF;

namespace FoodDelivery.DataAccess.EF.Repositories
{
    public class CountryRepository : BaseRepository<Country, FoodDeliveryDbContext>, ICountryRepository
    {
        public async Task<List<Country>> GetByCountryNameAsync(string name, params string[] includeList)
        {
            return await GetAllAsync(ctr => ctr.CountryName.Contains(name), includeList);
        }

        public async Task<Country> GetByIdAsync(int countryId, params string[] includeList)
        {
            return await GetAsync(ctr => ctr.CountryId == countryId, includeList);
        }
    }
}
